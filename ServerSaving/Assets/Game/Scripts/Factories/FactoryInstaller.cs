using Zenject;

namespace Game.Scripts.Factories
{
    public sealed class FactoryInstaller : Installer<FactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntityFactory>().To<EntityFactory>().AsSingle().NonLazy();
        }
    }
}