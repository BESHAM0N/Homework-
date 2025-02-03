using Zenject;

namespace Game.Scripts.Observers
{
    public sealed class GameObserversInstaller : Installer<GameObserversInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadGameObserver>().AsSingle().NonLazy();
            Container.Bind<SaveGameObserver>().AsSingle().NonLazy();
        }
    }
}