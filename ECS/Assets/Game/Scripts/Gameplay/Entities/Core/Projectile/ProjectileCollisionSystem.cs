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
        
        public void Run(IEcsSystems systems)
        {
            foreach (ProjectileCollisionRequest request in _collisionRequests.Value)
            {
                if (_takeDamageUseCase.Value.TakeDamage(request.projectile, request.target))
                {
                    _destroyRequests.Value.Fire(new DestroyRequest{entity = request.projectile.Id});
                }
            }
        }
    }
}