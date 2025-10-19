using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class ProjectileCollisionSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<ProjectileCollisionRequest> _collisionRequests;
        private readonly EcsEventInject<DestroyRequest> _destroyRequests;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamageUseCase;
        private readonly EcsPoolInject<TeamType> _teams;
        
        public void Run(IEcsSystems systems)
        {
            foreach (ProjectileCollisionRequest request in _collisionRequests.Value)
            {
                var world = systems.GetWorld();
                
                if (!request.projectile.Unpack(world, out int projectile) ||
                    !request.target.Unpack(world, out int target))
                    continue;
                
                if (_teams.Value.Has(projectile) && _teams.Value.Has(target))
                {
                    if (_teams.Value.Get(projectile) == _teams.Value.Get(target))
                        continue;
                }
                
                if (_takeDamageUseCase.Value.TakeDamage(request.projectile, request.target))
                {
                    _destroyRequests.Value.Fire(new DestroyRequest{entity = request.projectile.Id});
                }
            }
        }
    }
}