using Atomic.Elements;
using Atomic.Entities;
using Game.Context;
using SampleGame;

namespace Game.Gameplay
{
    public sealed class EnemyKillBehaviour : IEntityUpdate, IEntityInit
    {
        private IReactiveValue<int> _health;
        private bool _dead;
        private IEntityUpdate _entityUpdateImplementation;
        private IGameContext _gameContext;

        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _gameContext = GameContext.Instance;
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (_dead || _health.Value > 0)
                return;
            
            KillUseCase.TryAddKill(entity, _gameContext);
            _dead = true;
        }
    }
}