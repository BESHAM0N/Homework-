using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public sealed class UnitSpawnPointsInstaller : EcsViewInstaller
    {
        [SerializeField] private Transform[] _spawnPoints;

        public override void Install(in EcsWorld world, in int entity)
        {
            var pool = world.GetPool<UnitSpawnPoints>();
            ref var spawnPoints = ref (pool.Has(entity) ? ref pool.Get(entity) : ref pool.Add(entity));
            spawnPoints.points = _spawnPoints;
            spawnPoints.nextIndex = 0;
        }
    }
}