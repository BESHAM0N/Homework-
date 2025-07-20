using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _angularSpeed = 5f;
        [SerializeField] private int _health = 30;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private WeaponEntity _hand;
        [SerializeField] private float _cooldown;
        [SerializeField] private TriggerEventReceiver _enemyTrigger;

        private const float ATTACK_DISTANCE = 1f;
        
        public override void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.AddEnemyTag();
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddTrigger(_enemyTrigger);
            entity.AddTarget(new ReactiveVariable<IEntity>(null));
            InstallHealth(entity);
            InstallAttack(entity);
            InstallMove(entity);
            InstallRotate(entity);
        }

        private void InstallHealth(IEntity entity)
        {
            entity.AddDamageEvent(new BaseEvent<int>());
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddBehaviour<DeathAnimBehaviour>();
            entity.AddBehaviour<DamageAnimBehaviour>();
            entity.AddBehaviour<EnemyKillBehaviour>();
        }

        private void InstallAttack(IEntity entity)
        {
            entity.AddBehaviour<EnemyAttackBehavior>();
            entity.AddCurrentWeapon(_hand);
            
            entity.AddFireCondition(new BaseFunction<bool>(() =>
            {
                return HealthUseCase.IsAlive(entity)
                       && entity.GetCurrentWeapon().GetFireCondition().Invoke()
                       && entity.GetFireRotateDirection().Value != Vector3.zero; 
            }));
            
            var cooldown = new Cooldown(_cooldown);
            entity.WhenFixedUpdate(cooldown.Tick);
            entity.AddFireCooldown(cooldown);
            
            entity.AddFireEvent(new BaseEvent());
            
            entity.AddFireAction(new BaseAction(() =>
            {
                var fireCooldown = entity.GetFireCooldown();
                if (fireCooldown.IsExpired())
                {
                    entity.GetFireEvent().Invoke(); 
                    entity.GetCurrentWeapon().GetFireAction().Invoke();
                    fireCooldown.Reset();
                }
            }));
        }

        private void InstallMove(IEntity entity)
        {
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));

            entity.WhenFixedUpdate(_ =>
            {
                var target = entity.GetTarget().Value;
                if (target == null || !target.IsAlive())
                    return;

                var self = entity.GetTransform();
                var toTarget = target.GetTransform().position - self.position;
                var direction = toTarget.normalized;

                if (toTarget.magnitude > ATTACK_DISTANCE)
                {
                    entity.GetRotateDirection().Value = direction;
                }
            });
        }

        private void InstallRotate(IEntity entity)
        {
            entity.AddBehaviour<RotateBehaviour>();
            entity.AddRotateSpeed(new ReactiveVariable<float>(_angularSpeed));
            entity.AddRotateDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddRotateCondition(new AndExpression(entity.IsAlive));
        }
    }
}