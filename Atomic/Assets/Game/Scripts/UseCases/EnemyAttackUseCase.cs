using Atomic.Entities;
using SampleGame;

namespace Game.Gameplay
{
    public class EnemyAttackUseCase
    {
        private static void EnemyAttack(IEntity entity, float deltaTime)
        {
            // var target = entity.GetTarget().Value;
            //
            // if (target == null)
            //     return;
            //
            // var direction = entity.GetDirectionAt(target);
            // entity.Rotate(direction, deltaTime);
            //
            // var cooldown = entity.GetFireCooldown();
            // if (cooldown.IsExpired())
            // {
            //     // entity.GetHandWeapon().FireBullet();
            //     cooldown.Reset();
            // }
        } 
    }
}