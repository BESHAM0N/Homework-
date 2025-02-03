using Zenject;

namespace Game.Scripts.App.Server
{
    public sealed class ServerProxyInstaller : Installer<ServerProxyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ServerProxy>().AsSingle().NonLazy();
        }
    }
}