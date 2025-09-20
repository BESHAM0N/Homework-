using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<SpawnRequest> _requests;
        private readonly EcsUseCaseInject<SpawnUseCase> _useCase;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out SpawnRequest request))
                _useCase.Value.UnitSpawn(request.prefab, request.position, request.rotation, request.team);
        }
    }
}