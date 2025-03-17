using Game.Common;
using Game.Views;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    [CreateAssetMenu(
        fileName = "PresentersInstallers",
        menuName = "Zenject/New PresentersInstallers"
    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        [SerializeField] private PlanetCatalog _catalog;
        
        public override void InstallBindings()
        {
            Container.BindFactory<Planet, PlanetCard, PlanetCardPresenter, PlanetCardPresenter.Factory>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlanetPopupPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlanetPopupShower>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().NonLazy();
            Container.BindInstance(_catalog).AsSingle();
            Container.BindInterfacesAndSelfTo<PlanetUIBinder>().AsSingle().NonLazy();
        }
    }
}