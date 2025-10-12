using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSGame
{
    public sealed class MoveAnimSystem : IEcsRunSystem
    {
        private static readonly int Speed = Animator.StringToHash(nameof(Speed));

        private readonly EcsFilterInject<Inc<MoveableTag, AnimatorView>> _filter;
        private readonly EcsPoolInject<AnimatorView> _animators;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;

        public void Run(IEcsSystems systems)
        {
            float dt = Time.deltaTime;
            foreach (int entity in _filter.Value)
            {
                var speedValue = _moveUseCase.Value.GetSpeed(entity);
                var animator = _animators.Value.Get(entity).value;
                animator.SetFloat(Speed, speedValue, 0.1f, dt);
            }
        }
    }
}