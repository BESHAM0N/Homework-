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

            Debug.Log($"damage: {damage}");
            var health = entity.GetHealth();
            Debug.Log($"health: {health.Value}");
            var currentHealth = health.Value;

            if (currentHealth <= 0)
                return false;

            health.Value = Mathf.Max(0, currentHealth - damage);

            Debug.Log($"health: {health.Value}");
            
            if (entity.HasDamageEvent())
                entity.GetDamageEvent().Invoke(damage);

            return true;
        }
        
        public static bool AddHitPoints(in IEntity character, in int hp)
        {
            if (!character.TryGetHealth(out var health))
                return false;

            if (!character.IsAlive())
                return false;

            health.Value = Mathf.Min(health.Value + hp, character.GetMaxHealth());
            return true;
        }
    }
}