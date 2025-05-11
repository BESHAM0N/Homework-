using Atomic.Entities;
using Game.Gameplay;
using SampleGame;

namespace Game.Behavior
{
    public class EnemyAttackBehavior : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var target = entity.GetTarget().Value;
            
            if (target == null)
                return;

            var direction = entity.GetDirectionAt(target);
            entity.Rotate(direction, deltaTime);
            
            var cooldown = entity.GetFireCooldown();
            if (cooldown.IsExpired())
            {
               // entity.GetHandWeapon().FireBullet();
                cooldown.Reset();
            }
        }
    }
}