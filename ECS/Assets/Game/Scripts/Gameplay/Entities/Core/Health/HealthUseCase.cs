using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct HealthUseCase
    {
        private readonly EcsPoolInject<Health> _healths;

        public bool Reduce(in int entity, in int damage)
        {
            if (!_healths.Value.Has(entity)) return false;

            ref var health = ref _healths.Value.Get(entity);
            if (health.current <= 0) return false;

            health.current = math.max(0, health.current - math.max(0, damage));
            return true;
        }

        public bool Exists(int entity)
        {
            return _healths.Value.Has(entity) && _healths.Value.Get(entity).current > 0;
        }
    }
}