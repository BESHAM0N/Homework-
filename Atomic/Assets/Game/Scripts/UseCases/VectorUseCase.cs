using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class VectorUseCase
    {
        public static Vector3 GetDirectionAt(this IEntity entity, in IEntity target)
        {
            var currentPosition = entity.GetTransform().position;
            var targetPosition = target.GetTransform().position;
            var vector = targetPosition - currentPosition;
            vector.y = 0;
            
            return vector.normalized;
        }
    }
}