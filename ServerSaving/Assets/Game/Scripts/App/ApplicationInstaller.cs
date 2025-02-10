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
            RepositoryInstaller.Install(Container);
            SerializerInstaller.Install(Container);
            GameLoaderAndSaverInstaller.Install(Container);
        }
    }
}