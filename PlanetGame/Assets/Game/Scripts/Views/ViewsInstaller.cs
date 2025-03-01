using Game.Planets;
using Game.Scripts.UI.Currency;
using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private PlanetCard _planetCardPrefab;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private CatalogView _catalogViewPrefab;
        [SerializeField] private Transform _screenContainer;
        [SerializeField] private CurrencyView _currencyView;

        public override void InstallBindings()
        {
            PlanetPopupInstaller.Install(Container);
            Container.Bind<CatalogView>().FromComponentInNewPrefab(_catalogViewPrefab)
                .UnderTransform(_screenContainer)
                .AsSingle();
            CatalogViewInstaller.Install(Container, _catalogViewPrefab, _screenContainer);
            PlanetCardInstaller.Install(Container, _planetCardPrefab, _poolContainer);
            CurrencyInstaller.Install(Container, _currencyView);
        }
    }
}