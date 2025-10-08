using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct SpawnTransformUseCase
    {
        private readonly EcsPoolInject<UnitSpawnPoints> _spawnPoints;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;

        public (float3 pos, quaternion rot) GetNext(int baseEntity)
        {
            if (_spawnPoints.Value.Has(baseEntity))
            {
                ref var spawnPoints = ref _spawnPoints.Value.Get(baseEntity);
                var points = spawnPoints.points;
                if (points != null && points.Length > 0)
                {
                    int idx = spawnPoints.nextIndex;
                    spawnPoints.nextIndex = (idx + 1) % points.Length;

                    var point = points[idx];
                    if (point != null) 
                        return (point.position, point.rotation);
                }
            }

            float3 position = _positions.Value.Has(baseEntity) ? _positions.Value.Get(baseEntity).value : float3.zero;
            quaternion rotation = _rotations.Value.Has(baseEntity) ? _rotations.Value.Get(baseEntity).value : quaternion.identity;
            return (position, rotation);
        }
    }
}
