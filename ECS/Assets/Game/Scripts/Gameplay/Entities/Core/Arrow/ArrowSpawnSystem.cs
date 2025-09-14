using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public class ArrowSpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<ArrowSpawnRequest> _requests;
        private readonly EcsWorldInject _world;

        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _team;
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        
        public void Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out ArrowSpawnRequest request))
            {
                SpawnArrow(request);
            }
        }

        private void SpawnArrow(ArrowSpawnRequest spawnRequest)
        {
            var arrowPrefab = spawnRequest.prefab;
            var arrow = arrowPrefab.Create(_world.Value);
            
            _positions.Value.Add(arrow).value = spawnRequest.position;
            _rotations.Value.Add(arrow).value = spawnRequest.rotation;
            _team.Value.Add(arrow) = spawnRequest.team;
            
            _moveDirections.Value.Get(arrow).value = math.mul(spawnRequest.rotation, new float3(0, 0, 1));
        }
    }
}