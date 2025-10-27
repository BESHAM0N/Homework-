using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct TargetUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Position> _positionPool;
        private readonly EcsPoolInject<Health> _healthPool;
        private readonly EcsPoolInject<Target> _targetPool;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUseCase;

        public bool TryUnpack(in EcsPackedEntity packedEntity, out int entity) =>
            packedEntity.Unpack(_world.Value, out entity);
        
        private bool IsEnemy(int a, int b) => _teamUseCase.Value.IsEnemies(a, b);

        public bool IsAlive(int entity) =>
            _healthPool.Value.Has(entity) && _healthPool.Value.Get(entity).current > 0;

        private float GetSquaredDistance(int fromEntity, int toEntity)
        {
            var from = _positionPool.Value.Get(fromEntity).value;
            var to = _positionPool.Value.Get(toEntity).value;
            var delta = from - to;
            return math.lengthsq(delta);
        }
        
        public bool TryGetValidCurrentTarget(int unitEntity, out int currentTargetEntity) {
            currentTargetEntity = -1;
            if (!_targetPool.Value.Has(unitEntity)) return false;

            ref var packed = ref _targetPool.Value.Get(unitEntity).value;
            if (!TryUnpack(packed, out int targetEntity) || !IsAlive(targetEntity) || !IsEnemy(unitEntity, targetEntity)) {
                ClearTarget(unitEntity);
                return false;
            }

            currentTargetEntity = targetEntity;
            return true;
        }
        
        public void SetTarget(int unitEntity, int targetEntity) 
        {
            var packed = _world.Value.PackEntity(targetEntity);
            if (_targetPool.Value.Has(unitEntity))
                _targetPool.Value.Get(unitEntity).value = packed;
            else
                _targetPool.Value.Add(unitEntity).value = packed;
        }
        
        public void ClearTarget(int unitEntity) 
        {
            if (_targetPool.Value.Has(unitEntity))
                _targetPool.Value.Del(unitEntity);
        }
        
        public int FindNearestEnemy(int unitEntity, EcsFilter attackableCandidatesFilter) 
        {
            var best = -1;
            var bestDistSq = float.MaxValue;

            foreach (int candidate in attackableCandidatesFilter) {
                if (candidate == unitEntity) continue;
                if (!IsEnemy(unitEntity, candidate)) continue;
                if (!IsAlive(candidate)) continue;

                float squaredDistance = GetSquaredDistance(unitEntity, candidate);
                if (squaredDistance < bestDistSq) { bestDistSq = squaredDistance; best = candidate; }
            }
            return best;
        }
    }
}