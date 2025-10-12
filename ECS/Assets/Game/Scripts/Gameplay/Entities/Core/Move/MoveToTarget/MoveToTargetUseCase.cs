using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct MoveToTargetUseCase
    {
        private readonly EcsWorldInject _world;

        private readonly EcsPoolInject<MoveToTargetOrder> _orderPool;
        private readonly EcsPoolInject<Position> _positionPool;
        private readonly EcsPoolInject<MoveDirection> _moveDirectionPool;
        private readonly EcsPoolInject<Health> _healthPool;
        private readonly EcsPoolInject<UnitFireRequired> _fireRequiredPool;

        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUseCase;

        public void ProcessChaseStep(int unitEntity)
        {
            if (!_orderPool.Value.Has(unitEntity)) 
                return;

            ref MoveToTargetOrder order = ref _orderPool.Value.Get(unitEntity);

            if (!_targetUseCase.Value.TryUnpack(order.target, out int targetEntity) ||
                !_targetUseCase.Value.IsAlive(targetEntity) ||
                !_teamUseCase.Value.IsEnemies(unitEntity, targetEntity))
            {
                _orderPool.Value.Del(unitEntity);
                _moveDirectionPool.Value.Get(unitEntity).value = float3.zero;
                return;
            }

            float3 unitPosition = _positionPool.Value.Get(unitEntity).value;
            float3 targetPosition = _positionPool.Value.Get(targetEntity).value;
            float3 toTarget = targetPosition - unitPosition;

            float squaredDistance = math.lengthsq(toTarget);
            float stopDistanceSquared = order.stopDistance * order.stopDistance;

            if (squaredDistance > stopDistanceSquared)
            {
                _moveDirectionPool.Value.Get(unitEntity).value = math.normalizesafe(toTarget);
            }
            else
            {
                _moveDirectionPool.Value.Get(unitEntity).value = float3.zero;
                if (_fireRequiredPool.Value.Has(unitEntity)) 
                {
                    _fireRequiredPool.Value.Get(unitEntity).value = true;
                }
            }
        }
    }
}