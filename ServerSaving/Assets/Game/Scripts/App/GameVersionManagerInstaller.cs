using Zenject;

namespace Game.Scripts.App
{
    public sealed class GameVersionManagerInstaller : Installer<GameVersionManagerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameVersionManager>().AsSingle().NonLazy();
        }
    }
}