using Atomic.Entities;
using Game.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class HandUseCase
    {
        public static void MeleeAttack(this IWeaponEntity weapon)
        {
            var origin = weapon.GetFirePoint().position;
            var radius = weapon.GetHitRadius();
            var damage = 5;
            
            if (weapon.HasFireEvent())
                weapon.GetFireEvent().Invoke();

            Collider[] hits = Physics.OverlapSphere(origin, radius);

            foreach (var hit in hits)
            {
                if (!hit.TryGetComponent<SceneEntity>(out var entity))
                    continue;

                if (!entity.HasDamageableTag())
                    continue;

                entity.TakeDamage(damage);
                break;
            }
        }
    }
}