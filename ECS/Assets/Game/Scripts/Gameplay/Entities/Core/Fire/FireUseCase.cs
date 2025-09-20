using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct FireUseCase
    {
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _teams;
        private readonly EcsPoolInject<FireOffset> _fireOffsets;
        private readonly EcsPoolInject<FireCooldown> _fireCooldown;

        private readonly EcsEventInject<SpawnRequest> _spawnRequest;

        public void FireProjectile(in int entity, in EcsPrototype projectile)
        {
            _spawnRequest.Value.Fire(new SpawnRequest
            {
                prefab = projectile,
                position = this.GetFirePoint(entity),
                rotation = _rotations.Value.Get(entity).value,
                team = _teams.Value.Get(entity)
            });
        }

        public float3 GetFirePoint(in int entity)
        {
            var position = _positions.Value.Get(entity).value;
            var rotation = _rotations.Value.Get(entity).value;
            var offset = _fireOffsets.Value.Get(entity).value;
            return position + math.mul(rotation, offset);
        }

        public bool IsCooldownExpired(in int entity)
        {
            ref FireCooldown cooldown = ref _fireCooldown.Value.Get(entity);
            return cooldown.current <= 0;
        }

        public void ResetCooldown(int entity)
        {
            ref FireCooldown cooldown = ref _fireCooldown.Value.Get(entity);
            cooldown.current = cooldown.duration;
        }
    }
}