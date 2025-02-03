using Game.Scripts.App.Server;
using Game.Scripts.Controllers;
using Game.Scripts.Factories;
using Game.Scripts.Observers;
using Game.Scripts.Serialization;
using Zenject;

namespace Game.Scripts.App
{
    public sealed class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameVersionManagerInstaller.Install(Container);
            ServerProxyInstaller.Install(Container);
            SerializerInstaller.Install(Container);
            GameObserversInstaller.Install(Container);
            FactoryInstaller.Install(Container);
            EntityControllersInstaller.Install(Container);
        }
    }
}