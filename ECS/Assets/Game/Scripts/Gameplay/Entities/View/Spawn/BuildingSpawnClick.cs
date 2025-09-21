using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace ECSGame
{
    public class BuildingSpawnClick : MonoBehaviour
    {
        [Header("Spawn points (size = 3)")] [SerializeField]
        private Transform[] _spawnPoints = new Transform[3];

        private int _nextIndex;
        private EcsView _ecsView;
        private EcsWorld _world;

        private void Awake()
        {
            _ecsView = GetComponentInParent<EcsView>();
            _world = EcsAdmin.Systems?.GetWorld();
        }

        public void SpawnArcher() => Send(UnitType.Archer);
        public void SpawnSwordman() => Send(UnitType.Swordman);

        private void Send(UnitType type)
        {
            if (_world == null || _ecsView == null) return;

            var point = PickSpawnPoint();
            float3 pos = point.position;
            quaternion rot = point.rotation;

            _world.GetEvent<BuildingSpawnEvent>().Fire(new BuildingSpawnEvent
            {
                buildingEntity = _ecsView.Entity,
                unitType = type,
                position = pos,
                rotation = rot
            });
        }

        private Transform PickSpawnPoint()
        {
            if (_spawnPoints == null || _spawnPoints.Length == 0) return transform;

            int length = _spawnPoints.Length;
            for (int attempts = 0; attempts < length; attempts++)
            {
                int idx = _nextIndex++ % length;
                var point = _spawnPoints[idx];
                if (point != null) return point;
            }

            return transform;
        }
    }
}