using System.Collections.Generic;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private PlanetCard _planetCardPrefab;
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private Transform _screenContainer;
        [SerializeField] private List<Planet> _planets;
        
        public override void InstallBindings()
        {
            this.Container
                .Bind<PlanetPopup>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<MoneyView>().FromInstance(_moneyView).AsSingle();
        }
    }
}