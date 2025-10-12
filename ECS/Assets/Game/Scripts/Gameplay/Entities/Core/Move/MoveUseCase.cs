using Leopotam.EcsLite.Di;
using Unity.Burst;
using Unity.Mathematics;

namespace ECSGame
{
    [BurstCompile]
    public readonly struct MoveUseCase
    {
        private readonly EcsPoolInject<MoveDirection> _moveDirections;
        private readonly EcsPoolInject<MoveSpeed> _moveSpeed;
        
        public bool IsMoving(in int entity)
        {
            return math.any(_moveDirections.Value.Get(entity).value != float3.zero);
        }
        
        public float GetSpeed(in int entity)
        {
            var speed= _moveSpeed.Value.Get(entity).value;
            var dir= _moveDirections.Value.Get(entity).value;
            return math.length(dir) * speed;
        }
        
        [BurstCompile]
        public static void MoveStep(
            ref Position position, 
            in MoveDirection moveDirection, 
            in MoveSpeed moveSpeed, 
            in float deltaTime)
        {
            position.value += moveDirection.value * moveSpeed.value * deltaTime;
        }
    }
}