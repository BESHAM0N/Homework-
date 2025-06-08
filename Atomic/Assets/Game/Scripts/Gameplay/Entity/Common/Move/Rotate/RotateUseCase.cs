using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class RotateUseCase
    {
        public static void Rotate(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (entity.TryGetRotateCondition(out IExpression<bool> condition) && !condition.Value ||
                direction == Vector3.zero)
                return;

            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            Rotate(entity, targetRotation, deltaTime);
        }

        public static void Rotate(this IEntity entity, in Quaternion targetRotation, in float deltaTime)
        {
            var speed = entity.GetRotateSpeed().Value * deltaTime;
            var transform = entity.GetTransform();
            transform.rotation = Rotate(transform.rotation, targetRotation, speed);
        }

        public static Quaternion Rotate(in Quaternion currentRotation, in Quaternion targetRotation, in float speed)
        {
            return Quaternion.Lerp(currentRotation, targetRotation, speed);
        }
    }
}