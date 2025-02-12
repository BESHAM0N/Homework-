using Game.Scripts.App.Server;
using Game.Scripts.Observers;
using Game.Scripts.Serialization;
using Zenject;

namespace Game.Scripts.App
{
    public sealed class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntityWorldSerializer>().AsSingle().NonLazy();
            RepositoryInstaller.Install(Container);
            GameLoaderAndSaverInstaller.Install(Container);
        }
    }
}