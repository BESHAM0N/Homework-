using System;
using UnityEngine;
using Modules.Planets;
using Zenject;

namespace Game.Planets
{
    public class PlanetPopupPresenter : IPlanetPopupPresenter, IDisposable, IInitializable
    {
        public event Action OnStateChanged;
        
        public string PlanetName => _planet != null ? _planet.Name : string.Empty;
        public string Population => _planet != null ? _planet.Population.ToString() : string.Empty;
        public Sprite Icon => _planet?.GetIcon(_planet.IsUnlocked);
        public string CurrentLevel => _planet != null ? _planet.Level.ToString() : string.Empty;
        public string MaxLevel => _planet != null ? _planet.MaxLevel.ToString() : string.Empty;
        public string UpgradePrice => _planet != null ? _planet.Price.ToString() : string.Empty;
        public string Income => _planet != null ? _planet.MinuteIncome.ToString() : string.Empty;
        public bool IsUnlock => _planet?.IsUnlocked ?? false; 
        public bool IsNewUpgrade => _planet?.CanUpgrade ?? false; 
        
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

         void IInitializable.Initialize() { }

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

         public void Upgrade()
         {
             if (_planet != null && _planet.CanUpgrade)
             {
                 _planet.Upgrade();
                 OnStateChanged?.Invoke();
             }
         }
    }
}