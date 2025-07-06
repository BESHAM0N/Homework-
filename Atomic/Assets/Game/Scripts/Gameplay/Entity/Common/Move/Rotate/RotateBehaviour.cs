using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class RotateBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            Vector3 direction;
            direction = entity.HasRotateDirection() ? entity.GetRotateDirection().Value : entity.GetMoveDirection().Value;
            RotateUseCase.Rotate(entity, direction, deltaTime);
        }
    }
}