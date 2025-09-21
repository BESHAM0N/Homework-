using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public class UnitSpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<UnitSpawnRequest> _requests;
        private readonly EcsUseCaseInject<UnitSpawnUseCase> _useCase;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out UnitSpawnRequest request))
                _useCase.Value.UnitSpawn(request.prefab, request.position, request.rotation, request.team);
        }
    }
}