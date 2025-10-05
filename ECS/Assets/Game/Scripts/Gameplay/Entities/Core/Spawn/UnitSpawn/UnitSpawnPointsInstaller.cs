using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public sealed class UnitSpawnPointsInstaller : EcsViewInstaller
    {
        [Tooltip("Точки, из которых будут по кругу спавниться юниты.")] 
        [SerializeField] private Transform[] _spawnPoints;

        public override void Install(in EcsWorld world, in int entity)
        {
            var pool = world.GetPool<UnitSpawnPoints>();
            ref var spawnPoints = ref (pool.Has(entity) ? ref pool.Get(entity) : ref pool.Add(entity));
            spawnPoints.points = _spawnPoints;
            spawnPoints.nextIndex = 0;

#if UNITY_EDITOR
            if (spawnPoints.points == null || spawnPoints.points.Length == 0)
                Debug.LogWarning(
                    "[UnitSpawnPointsInstaller] Список точек пуст — юниты будут появляться у позиции базы.", this);
#endif
        }
    }
}