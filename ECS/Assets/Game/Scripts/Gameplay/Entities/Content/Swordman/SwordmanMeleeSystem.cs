using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class SwordmanMeleeSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SwordmanTag>> _swordmens;
        private readonly EcsUseCaseInject<AttackUseCase> _attack;

        public void Run(IEcsSystems _)
        {
            foreach (int entity in _swordmens.Value)
            {
                Fire(entity);
            }
        }

        private void Fire(int entity)
        {
            _attack.Value.TryAttack(entity);
        }
    }
}