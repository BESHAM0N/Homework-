using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public class MoveToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveToTargetOrder, Position, MoveDirection>> _unitsWithOrders;
        private readonly EcsUseCaseInject<MoveToTargetUseCase> _moveToTargetUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int unitEntity in _unitsWithOrders.Value)
            {
                _moveToTargetUseCase.Value.ProcessChaseStep(unitEntity);
            }
        }
    }
}