using System;
using Game.Presenters;
using UnityEngine;
using Modules.Planets;

namespace Game.Presenters
{
    public class PlanetPopupPresenter : IPlanetPopupPresenter, IDisposable
    {
        public event Action OnStateChanged;
        
        public string PlanetName => _planet != null ? _planet.Name : string.Empty;
        public string Population => _planet != null ? $"Population: {_planet.Population.ToString()}"  : string.Empty;
        public Sprite Icon => _planet?.GetIcon(_planet.IsUnlocked);
        public string UpgradePrice => _planet != null ? _planet.Price.ToString() : string.Empty;
        public string Income => _planet != null ? $"Income: {_planet.MinuteIncome.ToString()} / sec"  : string.Empty;
        public string LevelText => _planet != null ? $"Level: {_planet.Level.ToString()} / { _planet.MaxLevel.ToString()}"  : string.Empty;
        
        private IPlanet _planet;
        
         public void ChangePlanet(IPlanet planet)
         {
             if (_planet != null)
                 UnsubscribeFromPlanetEvents();
             
             _planet = planet;

             if (_planet != null)
                 SubscribeToPlanetEvents();
             
             OnStateChanged?.Invoke();
         }

         public void Dispose()
         {
             if (_planet != null)
             {
                 UnsubscribeFromPlanetEvents();
             }
         }

         private void SubscribeToPlanetEvents()
         {
             _planet.OnUnlocked += OnPlanetStateChanged;
             _planet.OnUpgraded += OnPlanetStateChanged;
             _planet.OnPopulationChanged += OnPlanetStateChanged;
         }

         private void UnsubscribeFromPlanetEvents()
         {
             _planet.OnUnlocked -= OnPlanetStateChanged;
             _planet.OnUpgraded -= OnPlanetStateChanged;
             _planet.OnPopulationChanged -= OnPlanetStateChanged;
         }

         private void OnPlanetStateChanged()
         {
             OnStateChanged?.Invoke();
         }
         
         private void OnPlanetStateChanged(int _)
         {
             OnStateChanged?.Invoke();
         }

         public bool CanUpgrade()
         {
             return _planet?.CanUpgrade ?? false;
         }

         //View->Presenter->Model->Presenter->View
         public void Upgrade()
         {
             if (_planet is { CanUpgrade: true })
             {
                 _planet.Upgrade();
                 //OnStateChanged?.Invoke();
             }
         }
    }
}