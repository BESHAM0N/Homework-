using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;

namespace Game.Context
{
    public sealed class BulletLifetimeBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private Cooldown _lifetime;
        private IAction _destroyAction;

        public void Init(in IEntity entity)
        {
            _destroyAction = entity.GetDestroyAction();
            _lifetime = entity.GetLifeTime();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _lifetime.Tick(deltaTime);
            
            if (_lifetime.IsExpired()) 
                _destroyAction.Invoke();
        }
    }
}