using Zenject;

namespace Game.Planets
{
    public class PlanetPopupInstaller : Installer<PlanetPopupInstaller>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<PlanetPopup>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            this.Container
                .BindInterfacesAndSelfTo<PlanetPopupPresenter>()
                .AsSingle();

            this.Container
                .BindInterfacesAndSelfTo<PlanetPopupShower>()
                .AsSingle();

        }
    }
}