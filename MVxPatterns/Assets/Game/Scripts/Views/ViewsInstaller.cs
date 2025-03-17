using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private PlanetCard _planetCardPrefab;
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private Transform _screenContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<ParticleAnimator>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<PlanetCard>().FromComponentsInHierarchy().AsCached();
            
            Container
                .Bind<PlanetPopup>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<MoneyView>().FromInstance(_moneyView).AsSingle();
            
        }
    }
}