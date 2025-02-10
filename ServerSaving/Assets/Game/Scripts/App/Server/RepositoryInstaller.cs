using Zenject;

namespace Game.Scripts.App.Server
{
    public sealed class RepositoryInstaller : Installer<RepositoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameRepository>().AsSingle().NonLazy();
        }
    }
}