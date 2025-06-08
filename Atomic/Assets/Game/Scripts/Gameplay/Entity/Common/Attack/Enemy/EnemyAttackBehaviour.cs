using Atomic.Entities;
using Game.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class EnemyAttackBehavior : IEntityFixedUpdate
    {
        private const float ATTACK_DISTANCE = 2.5f;

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var target = entity.GetTarget().Value;
            if (target == null || !target.IsAlive())
                return;

            var self = entity.GetTransform();
            var targetTransform = target.GetTransform();

            var toTarget = (targetTransform.position - self.position);
            var direction = toTarget.normalized;
            
            if (toTarget.magnitude > ATTACK_DISTANCE)
            {
                entity.Rotate(direction, deltaTime);
                entity.GetMoveAction().Invoke(direction, deltaTime);
            }
            else
            {
                var cooldown = entity.GetFireCooldown();
                if (cooldown.IsExpired())
                {
                    entity.GetHandWeapon().MeleeAttack();
                    cooldown.Reset();
                }
            }
        }
    }
}