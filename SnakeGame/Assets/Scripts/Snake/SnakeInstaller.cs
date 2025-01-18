using Zenject;
using Modules;

namespace SnakeGame
{
    public sealed class SnakeInstaller : Installer<Snake, SnakeInstaller>
    {
        private Snake _snakePrefab;

        [Inject]
        public void Construct(Snake snakePrefab)
        {
            _snakePrefab = snakePrefab;
        }

        public override void InstallBindings()
        {
            if (_snakePrefab == null)
            {
                throw new System.Exception("Snake prefab is not assigned.");
            }
         
            this.Container
                .Bind<ISnake>()
                .To<Snake>()
                .FromComponentInNewPrefab(_snakePrefab)
                .WithGameObjectName("Snake")
                .AsSingle();
        
            this.Container
                .BindInterfacesAndSelfTo<SnakeMoveController>()
                .AsSingle();
            
            this.Container.BindInterfacesAndSelfTo<SnakeExpandObserver>().AsSingle().NonLazy();;
            this.Container.BindInterfacesAndSelfTo<SnakeSpeedObserver>().AsSingle().NonLazy();;
            this.Container.BindInterfacesAndSelfTo<SnakeSelfColliderObserver>().AsSingle().NonLazy();;
            // this.Container.BindInterfacesAndSelfTo<SnakeOutOfBoundsAndPickupObserver>().AsSingle().NonLazy();
            this.Container.BindInterfacesAndSelfTo<SnakeOutOfBoundsObserver>().AsSingle().NonLazy();
            this.Container.BindInterfacesAndSelfTo<SnakePickupObserver>().AsSingle().NonLazy();
        }
    }
}