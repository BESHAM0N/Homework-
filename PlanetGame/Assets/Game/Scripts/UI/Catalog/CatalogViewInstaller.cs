using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public sealed class CatalogViewInstaller : Installer<CatalogView, Transform, CatalogViewInstaller>
    {
        [Inject]
        private CatalogView _catalogViewView;

        [Inject]
        private Transform _parent;
        
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesTo<CatalogPresenter>()
                .AsCached();
            
            this.Container
                .BindFactory<CatalogView, CatalogView.Factory>()
                .FromComponentInNewPrefab(_catalogViewView)
                .UnderTransform(_parent)
                .AsSingle();
        }
    }
}