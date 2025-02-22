using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public class PlanetIconInstaller : Installer<PlanetView, Transform, PlanetIconInstaller>
    {
        [Inject]
        private PlanetView _prefab;

        [Inject]
        private Transform _poolContainer;
        
        public override void InstallBindings()
        {
            this.Container
                .BindFactory<Planet, PlanetView, PlanetIconPresenter, PlanetIconPresenter.Factory>()
                .AsSingle();

            this.Container
                .BindMemoryPool<PlanetView, PlanetView.Pool>()
                .FromComponentInNewPrefab(_prefab)
                .UnderTransform(_poolContainer)
                .AsSingle();
            
            // Container
            //     .Bind<PlanetView>()
            //     .FromComponentInHierarchy()
            //     .AsSingle()
            //     .NonLazy();
            //
            // Container
            //     .BindInterfacesAndSelfTo<PlanetPresenter>()
            //     .AsSingle()
            //     .NonLazy();
        }
    }
}