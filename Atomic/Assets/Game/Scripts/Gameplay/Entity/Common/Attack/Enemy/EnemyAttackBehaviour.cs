using Atomic.Entities;
using Game.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyAttackBehavior : IEntityFixedUpdate
    {
        private const float ATTACK_DISTANCE = 1f;

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var target = entity.GetTarget().Value;
            if (target == null || !target.IsAlive())
            {
                entity.GetMoveDirection().Value = Vector3.zero;
                return;
            }

            var self = entity.GetTransform();
            var targetTransform = target.GetTransform();

            var toTarget = (targetTransform.position - self.position);
            var direction = toTarget.normalized;

            if (toTarget.magnitude > ATTACK_DISTANCE)
            {
                entity.GetMoveDirection().Value = direction;

                entity.Rotate(direction, deltaTime);
                entity.GetMoveAction().Invoke(direction, deltaTime);
            }
            else
            {
                entity.GetMoveDirection().Value = Vector3.zero;

                var cooldown = entity.GetFireCooldown();
                if (cooldown.IsExpired())
                {
                    entity.GetFireEvent().Invoke();
                    entity.GetHandWeapon().MeleeAttack();
                    cooldown.Reset();
                }
            }
        }
    }
}