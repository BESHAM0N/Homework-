using System;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class HealthUseCase
    {
        public static bool IsAlive(this IEntity entity)
        {
            return entity.GetHealth().Value > 0;
        }

        public static bool TakeDamage(this IEntity entity, int damage)
        {
            if (!entity.HasDamageableTag())
                return false;

            var health = entity.GetHealth();
            var currentHealth = health.Value;

            if (currentHealth <= 0)
                return false;

            health.Value = Mathf.Max(0, currentHealth - damage);

            if (entity.HasDamageEvent())
                entity.GetDamageEvent().Invoke(damage);

            return true;
        }
    }
}