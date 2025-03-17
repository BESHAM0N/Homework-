using System;
using Game.Views;
using Modules.Planets;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public class PlanetCardPresenter : IInitializable, IDisposable
    {
        //Model:
        private readonly Planet _planet;

        //Domain layer:
        private readonly IPlanetShower _planetShower;

        //View:
        private readonly PlanetCard _card;
        
        private readonly MoneyPresenter _moneyPresenter;
        private readonly ParticleAnimator _particleAnimator;

        public PlanetCardPresenter(PlanetCard card, Planet planet, IPlanetShower planetShower, MoneyPresenter moneyPresenter, ParticleAnimator particleAnimator)
        {
            _card = card;
            _planetShower = planetShower;
            _planet = planet;
            _moneyPresenter = moneyPresenter;
            _particleAnimator = particleAnimator;
        }

        public void Initialize()
        {
            _card.OnClicked += OnPlanetClicked;
            _card.OnClickedMoneyIcon += CollectMoney;
            _card.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _card.SetPrice(_planet.Price.ToString());
            _card.SetTimer(_planet.MinuteIncome.ToString());

            _planet.OnUnlocked += OnPlanetUnlocked;
            _planet.OnIncomeReady += OnIncomeReady;
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnGathered += OnGathered;
        }

        public void Dispose()
        {
            _card.OnClicked -= OnPlanetClicked;
            _card.OnClickedMoneyIcon -= CollectMoney;
            
            _planet.OnUnlocked -= OnPlanetUnlocked;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnGathered -= OnGathered;
        }

        private void OnGathered(int money)
        {
            //TODO: Анимация движения монетки через particleAnimator.Emit
            
            var startPos = _card.MoneyIconPosition.position;
            var targetPos = _moneyPresenter.MoneyTransform;
          
            _particleAnimator.Emit(startPos, targetPos, 1f, () =>
            {
                // Этот callback вызывается после завершения анимации
                Debug.Log("Анимация монетки завершена");
            });
        }

        private void OnPlanetClicked()
        {
            if (_planet.IsUnlocked)
            {
                _planetShower.Show(_planet);
            }
            else
            {
                _planet.Unlock();
            }
        }

        private void OnPlanetUnlocked()
        {
            _card.SetActiveLock(_planet.IsUnlocked);
            _card.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
        }

        private void OnIncomeReady(bool isReady)
        {
            _card.SetProgressBar(!isReady);
        }

        private void OnIncomeTimeChanged(float timeRemaining)
        {
            if (timeRemaining > 0)
            {
                var formattedTime = timeRemaining.ToString("F1") + "s";
                _card.SetTimer(formattedTime);
            }
            else
            {
                _card.SetProgressBar(false);
            }
        }
        
        private void CollectMoney()
        {
            if (!_planet.IsIncomeReady) return;
            _planet.GatherIncome();
        }

        public sealed class Factory : PlaceholderFactory<Planet, PlanetCard, PlanetCardPresenter>
        {
        }
    }
}