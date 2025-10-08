using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSGame
{
    public sealed class MoveAnimSystem : IEcsRunSystem
    {
        private static readonly int Walk = Animator.StringToHash(nameof(Walk));

        private readonly EcsFilterInject<Inc<MoveableTag, AnimatorView>> _moveables;
        private readonly EcsPoolInject<AnimatorView> _animators;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _moveables.Value)
            {
                var isMoving = _moveUseCase.Value.IsMoving(entity);
                var animator = _animators.Value.Get(entity).value;

                if (isMoving)
                    animator.SetTrigger(Walk);
            }
        }
    }
}