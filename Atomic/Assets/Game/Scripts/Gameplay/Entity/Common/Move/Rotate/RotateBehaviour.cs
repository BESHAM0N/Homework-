using Atomic.Entities;
using Game.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
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