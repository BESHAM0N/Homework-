using Modules.Planets;
using Zenject;

namespace Game.Gameplay
{
    //Don't modify
    public sealed class PlanetInstaller : Installer<PlanetCatalog, PlanetInstaller>
    {
        [Inject]
        private PlanetCatalog _catalog;

        // public override void InstallBindings()
        // {
        //     foreach (PlanetConfig config in _catalog)
        //     {
        //         this.Container
        //             .BindInterfacesAndSelfTo<Planet>()
        //             .AsCached()
        //             .WithArguments(config)
        //             .NonLazy();
        //     }
        // }
        public override void InstallBindings()
        {
            Container.Bind<PlanetRegistry>().AsSingle().NonLazy();

            foreach (PlanetConfig config in _catalog)
            {
                var planet = Container.Instantiate<Planet>(new object[] { config });
                
                Container.Resolve<PlanetRegistry>().Register(config, planet);

                Container.BindInterfacesAndSelfTo<Planet>()
                    .FromInstance(planet)
                    .AsCached()
                    .WithArguments(config)
                    .NonLazy();
            }
        }
    }
}