using Unity.Burst;

namespace ECSGame
{
    [BurstCompile]
    public static class MoveUseCase
    {
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