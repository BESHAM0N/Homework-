using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class TargetSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world;

        private readonly EcsFilterInject<Inc<UnitFireRequired, TeamType, Position, Health, AttackRange>>
            _attackerEntitys;

        private readonly EcsFilterInject<Inc<AttackableTag, TeamType, Position, Health>> _attackableEntitys;

        private readonly EcsPoolInject<AttackRange> _attackRangePool;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;

        private readonly EcsEventInject<MoveToTargetRequest> _moveRequests;

        public void Run(IEcsSystems _)
        {
            foreach (int unitEntity in _attackerEntitys.Value)
            {
                int targetEntity;

                if (!_targetUseCase.Value.TryGetValidCurrentTarget(unitEntity, out targetEntity))
                {
                    targetEntity = _targetUseCase.Value.FindNearestEnemy(unitEntity, _attackableEntitys.Value);

                    if (targetEntity == -1)
                    {
                        _targetUseCase.Value.ClearTarget(unitEntity);
                        continue;
                    }

                    _targetUseCase.Value.SetTarget(unitEntity, targetEntity);
                }

                var attackRange = _attackRangePool.Value.Get(unitEntity).value;

                _moveRequests.Value.Fire(new MoveToTargetRequest
                {
                    unitEntity = unitEntity,
                    target = _world.Value.PackEntity(targetEntity),
                    stopDistance = attackRange
                });
            }
        }
    }
}