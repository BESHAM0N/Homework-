using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public class ProjectileSpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<ProjectileSpawnRequest> _requests;

        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsUseCaseInject<UnitSpawnUseCase> _useCase;
        private readonly EcsPoolInject<EcsName> _names;
        private readonly EcsPoolInject<TeamType> _teamTypes;
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        
        public void Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out ProjectileSpawnRequest request))
                SpawnBullet(request);
        }

        private void SpawnBullet(ProjectileSpawnRequest spawnRequest)
        {
            // EcsPrototype prefab = spawnRequest.prefab;
            // int projectile = prefab.Create(_world.Value);
            
            // _positions.Value.Add(projectile).value = spawnRequest.position;
            // _rotations.Value.Add(projectile).value = spawnRequest.rotation;
            // _teamTypes.Value.Add(projectile) = spawnRequest.team;
            
            var projectile  = _useCase.Value.UnitSpawn(spawnRequest.prefab, spawnRequest.position, spawnRequest.rotation, spawnRequest.team);
            
            if (!_names.Value.Has(projectile)) 
                _names.Value.Add(projectile);
            
            _names.Value.Get(projectile).value = spawnRequest.prefab.name;
            
            if (!_moveDirections.Value.Has(projectile)) 
                _moveDirections.Value.Add(projectile);
            
            _moveDirections.Value.Get(projectile).value = math.mul(spawnRequest.rotation, new float3(0, 0, 1));
        }
    }
}