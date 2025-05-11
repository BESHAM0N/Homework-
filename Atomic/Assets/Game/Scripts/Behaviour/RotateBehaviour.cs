using Atomic.Entities;
using Game.Gameplay;
using SampleGame;

namespace Game.Behavior
{
    public class RotateBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var direction = entity.GetMoveDirection().Value;
            RotateUseCase.Rotate(entity, direction, deltaTime);
        }
    }
}