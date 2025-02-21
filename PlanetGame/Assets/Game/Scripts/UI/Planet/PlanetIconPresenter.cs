using System;
using Modules.Money;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public class PlanetIconPresenter : IInitializable, IDisposable
    {
        //Model:
        private readonly Planet _planet;
        private readonly IMoneyStorage _moneyStorage;
        
        //Domain layer:
        private readonly IPlanetShower _planetShower;
        
        //View:
        private readonly PlanetIcon _view;

        public PlanetIconPresenter(PlanetIcon view, Planet planet, IMoneyStorage moneyStorage, IPlanetShower planetShower)
        {
            _view = view;
            _planet = planet;
            _moneyStorage = moneyStorage;
            _planetShower = planetShower;
        }
        
        public void Initialize()
        {
            _view.OnClicked += OnPlanetClicked;
            // _view.SetActiveLock(_planet.IsUnlocked);
            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetPrice(_planet.Price.ToString());
            _view.SetTimer(_planet.MinuteIncome.ToString());
            
            _planet.OnUnlocked += OnPlanetActiveChanged;
        }

        public void Dispose()
        {
            _view.OnClicked -= OnPlanetClicked;
            _planet.OnUnlocked -= OnPlanetActiveChanged;
        }

        private void OnPlanetClicked()
        {
            if (_planet.IsUnlocked)
            {
               _planetShower.Show(_planet);
                return;
            }

            if (_moneyStorage.IsEnough(_planet.Price))
            {
                _moneyStorage.Spend(_planet.Price);
                _planet.Unlock();
            }
            else
            {
                Debug.Log($"Insufficient funds to purchase {_planet.Name}");
            }
        }

        private void OnPlanetActiveChanged()
        {
            _view.SetActiveLock(_planet.IsUnlocked);
        }

        private void PlanetChanged()
        {
            
        }
        
        public sealed class Factory : PlaceholderFactory<Planet, PlanetIcon, PlanetIconPresenter>
        {
        }
    }
}