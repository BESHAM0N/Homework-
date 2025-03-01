using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public class PlanetCardInstaller : Installer<PlanetCard, Transform, PlanetCardInstaller>
    {
        [Inject]
        private PlanetCard _prefab;
        
        [Inject]
        private Transform _poolContainer;
        
        public override void InstallBindings()
        {
            Container.BindFactory<PlanetConfig, PlanetCard, PlanetCardPresenter, PlanetCardPresenter.Factory>()
                .AsSingle();
           
            Container.BindMemoryPool<PlanetCard, PlanetCard.Pool>()
                .FromComponentInNewPrefab(_prefab)
                .UnderTransform(_poolContainer)
                .AsSingle();
        }
    }
}