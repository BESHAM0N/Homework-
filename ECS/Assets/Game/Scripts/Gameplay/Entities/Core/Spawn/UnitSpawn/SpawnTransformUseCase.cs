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
                ref var sp = ref _spawnPoints.Value.Get(baseEntity);
                var pts = sp.points;
                if (pts != null && pts.Length > 0)
                {
                    int idx = sp.nextIndex;
                    sp.nextIndex = (idx + 1) % pts.Length;

                    var t = pts[idx];
                    if (t != null) return (t.position, t.rotation);
                }
            }
            
            float3 pos = _positions.Value.Has(baseEntity) ? _positions.Value.Get(baseEntity).value : float3.zero;
            quaternion rot = _rotations.Value.Has(baseEntity) ? _rotations.Value.Get(baseEntity).value : quaternion.identity;
            return (pos, rot);
        }
    }
}
