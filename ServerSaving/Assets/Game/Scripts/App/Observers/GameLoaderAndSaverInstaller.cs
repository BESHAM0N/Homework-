using Zenject;

namespace Game.Scripts.Observers
{
    public sealed class GameLoaderAndSaverInstaller : Installer<GameLoaderAndSaverInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSaveLoader>().AsSingle().NonLazy();
        }
    }
}