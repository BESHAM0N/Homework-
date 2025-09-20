using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSGame
{
    public sealed class MoveAnimSystem : IEcsRunSystem
    {
        private static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        
        private readonly EcsFilterInject<Inc<MoveableTag, AnimatorView>> _moveables;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _moveables.Value)
            {
                ref var animator = ref _moveables.Pools.Inc2.Get(entity);
                var isMoving = _moveUseCase.Value.IsMoving(entity);
                animator.value.SetBool(IsMoving, isMoving);
            }
        }
    }
}