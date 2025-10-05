using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public class UnitSpawnSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<UnitSpawnRequest> _requests;
        private readonly EcsUseCaseInject<UnitSpawnUseCase> _useCase;
        private readonly EcsPoolInject<EcsName> _names;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            while (_requests.Value.Consume(out UnitSpawnRequest request))
            {
                var entity = _useCase.Value.UnitSpawn(request.prefab, request.position, request.rotation, request.team);
                if (!string.IsNullOrEmpty(request.viewKey))
                {
                    var pool = _names.Value;
                    if (!pool.Has(entity)) pool.Add(entity);
                    pool.Get(entity).value = request.viewKey;
                }
            }
        }
    }
}