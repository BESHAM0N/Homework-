using Atomic.Entities;
using SampleGame;

namespace Game.Behavior
{
    public sealed class MoveBehaviour : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            var direction = entity.GetMoveDirection().Value;
            entity.GetMoveAction().Invoke(direction, deltaTime);
        }
    }
}