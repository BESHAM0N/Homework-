using Atomic.Elements;
using Atomic.Entities;
using SampleGame;

namespace Game.Gameplay
{
    public sealed class EnemyKillBehaviour : IEntityUpdate, IEntityInit
    {
        private IReactiveValue<int> _health;
        private bool _dead;
        private IEntityUpdate _entityUpdateImplementation;

        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (_dead || _health.Value > 0)
                return;

            KillUseCase.TryAddKill(entity);
            _dead = true;
        }
    }
}