using System;
using Modules.Planets;
using Zenject;

namespace Game.Planets
{
    public class PlanetCardPresenter : IInitializable, IDisposable
    {
        public PlanetCard Card => _card;

        //Model:
        private readonly Planet _planet;
        
        //Domain layer:
        private readonly IPlanetShower _planetShower;

        //View:
        private readonly PlanetCard _card;

        public PlanetCardPresenter(PlanetCard card, PlanetConfig config,
            IPlanetShower planetShower, PlanetRegistry planetRegistry)
        {
            _card = card;
            _planetShower = planetShower;
            _planet = planetRegistry.GetPlanet(config);
        }

        public void Initialize()
        {
            _card.OnClicked += OnPlanetClicked;
            _card.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _card.SetPrice(_planet.Price.ToString());
            _card.SetTimer(_planet.MinuteIncome.ToString());

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
            _card.SetTimer(isReady ? "Ready!" : _planet.MinuteIncome.ToString());
            _card.SetProgressBar(!isReady);
        }

        private void OnIncomeTimeChanged(float timeRemaining)
        {
            var formattedTime = timeRemaining > 0 ? timeRemaining.ToString("F1") + "s" : "Ready!";
            _card.SetTimer(formattedTime);
        }

        public sealed class Factory : PlaceholderFactory<PlanetConfig, PlanetCard, PlanetCardPresenter>
        {
        }
    }
}