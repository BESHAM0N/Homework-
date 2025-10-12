using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public readonly struct AttackUseCase
    {
        private readonly EcsWorldInject _world;

        private readonly EcsPoolInject<UnitFireRequired> _fireFlag;
        private readonly EcsPoolInject<Target> _targetPool;
        private readonly EcsPoolInject<AttackRange> _attackRangePool;
        private readonly EcsPoolInject<Health> _healthPool;
        private readonly EcsPoolInject<Damage> _damagePool;

        private readonly EcsUseCaseInject<HealthUseCase> _healthUse;
        private readonly EcsUseCaseInject<FireProjectileUseCase> _fireUse;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUse;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUse;

        private readonly EcsEventInject<FireEvent> _fireEvents;

        private bool Attack(int attacker, out int target)
        {
            target = -1;

            ref var fireReq = ref _fireFlag.Value.Get(attacker);
            if (!fireReq.value) return false;
            fireReq.value = false;

            if (!_fireUse.Value.IsCooldownExpired(attacker)) return false;
            if (!_healthUse.Value.Exists(attacker)) return false;

            if (!_targetPool.Value.Has(attacker)) return false;
            ref var packed = ref _targetPool.Value.Get(attacker).value;
            if (!_targetUse.Value.TryUnpack(packed, out target)) return false;
            if (!_healthPool.Value.Has(target) || _healthPool.Value.Get(target).current <= 0) return false;

            return true;
        }

        public bool TryAttack(int attacker, EcsPrototype projectilePrefab)
        {
            if (!Attack(attacker, out _)) return false;

            _fireUse.Value.FireProjectile(attacker, projectilePrefab);
            _fireUse.Value.ResetCooldown(attacker);
            _fireEvents.Value.Fire(new FireEvent { entity = _world.Value.PackEntity(attacker) });
            return true;
        }

        public bool TryAttack(int attacker)
        {
            if (!Attack(attacker, out int target)) return false;

            var damage = _damagePool.Value.Get(attacker).value;
            ref var health = ref _healthPool.Value.Get(target);
            health.current = math.max(0, health.current - damage);

            _fireUse.Value.ResetCooldown(attacker);
            _fireEvents.Value.Fire(new FireEvent { entity = _world.Value.PackEntity(attacker) });
            return true;
        }
    }
}