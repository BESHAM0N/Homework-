using Zenject;

namespace Game.Scripts.Controllers
{
    public sealed class EntityControllersInstaller : Installer<EntityControllersInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntitiesDestroyController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EntitySpawnController>().AsSingle().NonLazy();
        }
    }
}