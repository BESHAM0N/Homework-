using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class ArcherFireSystem : IEcsRunSystem
    {
        private readonly EcsPrototype _arrowPrefab;
        private readonly EcsFilterInject<Inc<ArcherTag>> _archers;
        private readonly EcsUseCaseInject<AttackUseCase> _attack;

        public ArcherFireSystem(EcsPrototype prefab)
        {
            _arrowPrefab = prefab;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int archer in _archers.Value)
            {
                Fire(archer);
            }
        }

        private void Fire(int entity)
        {
            _attack.Value.TryAttack(entity, _arrowPrefab);
        }
    }
}