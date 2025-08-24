using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSGame
{
    public sealed class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveableTag>> _moveables;
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        private readonly EcsPoolInject<MoveSpeed> _moveSpeeds;
        private readonly EcsPoolInject<Position> _positions;

        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;
            foreach (var entity in _moveables.Value)
            {
                ref MoveDirection moveDirection = ref _moveDirections.Value.Get(entity);
                ref MoveSpeed moveSpeed = ref _moveSpeeds.Value.Get(entity);
                ref Position position = ref _positions.Value.Get(entity);
                
                //Вся бизнес-логика уходит в UseCase
                MoveUseCase.MoveStep(ref position, in moveDirection, in moveSpeed, in deltaTime);
            }
        }
    }
}