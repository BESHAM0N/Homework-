using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public sealed class ArcherFireSystem : IEcsRunSystem
    {
        private readonly EcsPrototype _arrowPrefab;

        private readonly EcsFilterInject<Inc<ArcherTag>> _units;
        private readonly EcsPoolInject<UnitFireRequired> _fireRequired;

        private readonly EcsPoolInject<Position> _positions;
        private readonly EcsPoolInject<Rotation> _rotations;
        private readonly EcsPoolInject<TeamType> _teams;
        private readonly EcsPoolInject<FireOffset> _fireOffset;

        private readonly EcsEventInject<ArrowSpawnRequest> _arrowSpawnRequests;
        private readonly EcsEventInject<FireEvent> _fireEvents;
        private readonly EcsWorldInject _world;

        public ArcherFireSystem(EcsPrototype prefab)
        {
            _arrowPrefab = prefab;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref UnitFireRequired fireRequired = ref _fireRequired.Value.Get(entity);

                if (!fireRequired.value) continue;

                var position = _positions.Value.Get(entity).value;
                var rotation = _rotations.Value.Get(entity).value;
                var offset = _fireOffset.Value.Get(entity).value;
                
                _arrowSpawnRequests.Value.Fire(new ArrowSpawnRequest()
                {
                    prefab = _arrowPrefab,
                    position = position + math.mul(rotation, offset),
                    rotation = rotation,
                    team = _teams.Value.Get(entity)
                });

                //TODO: Вынести в структуру 
                _fireEvents.Value.Fire(new FireEvent{entity = _world.Value.PackEntity(entity)});
            }
        }
    }
}