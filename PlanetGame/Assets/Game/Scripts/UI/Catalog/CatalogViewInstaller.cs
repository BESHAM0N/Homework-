using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public sealed class CatalogViewInstaller : Installer<CatalogView, Transform, CatalogViewInstaller>
    {
        [Inject]
        private CatalogView _catalogView;

        [Inject]
        private Transform _parent;
        
        public override void InstallBindings()
        {
            this.Container
                .BindFactory<CatalogView, CatalogView.Factory>()
                .FromComponentInNewPrefab(_catalogView)
                .UnderTransform(_parent)
                .AsSingle();
            
            this.Container
                .BindInterfacesAndSelfTo<CatalogPresenter>()
                .AsCached();
        }
    }
}