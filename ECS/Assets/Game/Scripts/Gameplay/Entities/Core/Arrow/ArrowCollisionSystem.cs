using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class ArrowCollisionSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<ArrowCollisionRequest> _collisionRequests;
        private readonly EcsEventInject<DestroyRequest> _destroyRequests;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamageUseCase;
        
        public void Run(IEcsSystems systems)
        {
            foreach (ArrowCollisionRequest request in _collisionRequests.Value)
            {
                if (_takeDamageUseCase.Value.TakeDamage(request.arrow, request.target))
                {
                    _destroyRequests.Value.Fire(new DestroyRequest{entity = request.arrow.Id});
                }
            }
        }
    }
}