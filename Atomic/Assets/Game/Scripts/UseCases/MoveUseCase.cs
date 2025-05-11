using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void Move(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (entity.TryGetMoveCondition(out IExpression<bool> condition) && !condition.Value)
                return;

            Transform transform = entity.GetTransform();
            IValue<float> speed = entity.GetMoveSpeed();
            transform.position += direction * (speed.Invoke() * deltaTime);
        }

        public static void MoveSelf(this IEntity entity, float deltaTime)
        {
            var direction = entity.GetMoveDirection();
            entity.Move(direction.Value, deltaTime);
        }
    }
}