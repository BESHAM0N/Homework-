using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct UnitSpawnUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _teams;

        public int UnitSpawn(in EcsPrototype prototype, in float3 position, in quaternion rotation, in TeamType team)
        {
            var entity = prototype.Create(_world.Value);
            _positions.Value.Add(entity).value = position;
            _rotations.Value.Add(entity).value = rotation;
            _teams.Value.Add(entity) = team;
            return entity;
        }
    }
}