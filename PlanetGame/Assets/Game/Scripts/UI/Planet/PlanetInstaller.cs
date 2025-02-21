using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public class PlanetIconInstaller : Installer<PlanetIcon, Transform, PlanetIconInstaller>
    {
        [Inject]
        private PlanetIcon _prefab;

        [Inject]
        private Transform _poolContainer;
        
        public override void InstallBindings()
        {
            this.Container
                .BindFactory<Planet, PlanetIcon, PlanetIconPresenter, PlanetIconPresenter.Factory>()
                .AsSingle();

            this.Container
                .BindMemoryPool<PlanetIcon, PlanetIcon.Pool>()
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