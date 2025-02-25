using System;
using Modules.Money;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public class PlanetCardPresenter : IInitializable, IDisposable
    {
        public PlanetCard Card => _card;
        
        //Model:
        private readonly Planet _planet;
        private readonly IMoneyStorage _moneyStorage;

        //Domain layer:
        private readonly IPlanetShower _planetShower;

        //View:
        private readonly PlanetCard _card;

        public PlanetCardPresenter(PlanetCard card, Planet planet, IMoneyStorage moneyStorage,
            IPlanetShower planetShower)
        {
            _card = card;
            _planet = planet;
            _moneyStorage = moneyStorage;
            _planetShower = planetShower;
        }

        public void Initialize()
        {
            _card.OnClicked += OnPlanetClicked;
            _card.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _card.SetPrice(_planet.Price.ToString());
            _card.SetTimer(_planet.MinuteIncome.ToString());
            _card.SetActiveLock(_planet.IsUnlocked);
            
            _planet.OnUnlocked += OnPlanetUnlocked;
            _planet.OnIncomeReady += OnIncomeReady;
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
        }

        public void Dispose()
        {
            _card.OnClicked -= OnPlanetClicked;
            _planet.OnUnlocked -= OnPlanetUnlocked;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
        }

        private void OnPlanetClicked()
        {
            if (_planet.IsUnlocked)
            {
                _planetShower.Show(_planet);
            }
            else if (_moneyStorage.IsEnough(_planet.Price))
            {
                _moneyStorage.Spend(_planet.Price);
                _planet.Unlock();
            }
            else
            {
                Debug.Log($"Insufficient funds to purchase {_planet.Name}");
            }
        }

        private void OnPlanetUnlocked()
        {
            _card.SetActiveLock(_planet.IsUnlocked);
            _card.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
        }

        private void OnIncomeReady(bool isReady)
        {
            _card.SetTimer(isReady ? "Ready!" : _planet.MinuteIncome.ToString());
        }

        private void OnIncomeTimeChanged(float timeRemaining)
        {
            _card.SetTimer(timeRemaining.ToString("F2"));
        }

        public sealed class Factory : PlaceholderFactory<Planet, PlanetCard, PlanetCardPresenter>
        {
        }
    }
}