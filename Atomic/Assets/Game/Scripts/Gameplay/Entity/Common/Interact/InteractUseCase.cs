using System.Buffers;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class InteractUseCase
    {
        private const int COLLIDER_BUFFER_SIZE = 32;

        public static bool Interact(in IEntity source, in IEntity target)
        {
            if (source == null)
                return false;

            if (target == null || !target.HasInteractibleTag())
                return false;

            target.GetInteractAction().Invoke(source);
            return true;
        }

        public static bool InteractAsCharacter(in IEntity character)
        {
            IEntity interactible = character.GetTargetInteractible().Value;
            return Interact(character, interactible);
        }

        public static bool FindClosest(
            in Vector3 center,
            in float radius,
            in LayerMask layerMask,
            in QueryTriggerInteraction triggerInteraction,
            out IEntity interactible
        )
        {
            ArrayPool<Collider> arrayPool = ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(COLLIDER_BUFFER_SIZE);

            int count = Physics.OverlapSphereNonAlloc(center, radius, colliders, layerMask, triggerInteraction);

            float minDistance = float.MaxValue;
            interactible = null;

            for (int i = 0; i < count; i++)
            {
                Collider collider = colliders[i];
                if (!collider.TryGetEntity(out IEntity other) || !other.HasInteractibleTag())
                    continue;

                Vector3 position = other.GetTransform().position;
                float distance = Vector3.SqrMagnitude(position - center);
                if (distance >= minDistance)
                    continue;

                interactible = other;
                minDistance = distance;
            }
            
            arrayPool.Return(colliders);
            return interactible != null;
        }
    }
}