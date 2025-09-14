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

        public ArcherFireSystem(EcsPrototype prefab)
        {
            _arrowPrefab = prefab;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var unit in _units.Value)
            {
                ref UnitFireRequired fireRequired = ref _fireRequired.Value.Get(unit);

                if (!fireRequired.value) continue;

                var position = _positions.Value.Get(unit).value;
                var rotation = _rotations.Value.Get(unit).value;
                var offset = _fireOffset.Value.Get(unit).value;
                
                _arrowSpawnRequests.Value.Fire(new ArrowSpawnRequest()
                {
                    prefab = _arrowPrefab,
                    position = position + math.mul(rotation, offset),
                    rotation = rotation,
                    team = _teams.Value.Get(unit)
                });
            }
        }
    }
}