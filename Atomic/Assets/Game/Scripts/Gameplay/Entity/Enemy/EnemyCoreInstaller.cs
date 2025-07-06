using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 1;
        [SerializeField] private float _angularSpeed = 5;
        [SerializeField] private int _health = 30;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private WeaponEntity _hand;
        [SerializeField] private float _cooldown;
        [SerializeField] private TriggerEventReceiver _enemyTrigger;
        
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
            var cooldown = new Cooldown(_cooldown);
            entity.WhenFixedUpdate(cooldown.Tick);
            entity.AddFireCooldown(cooldown);
            entity.AddFireEvent(new BaseEvent());
        }

        private void InstallMove(IEntity entity)
        {
            entity.AddBehaviour<MoveBehaviour>();
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            entity.AddMoveAction(new BaseAction<Vector3, float>((direction, deltaTime) =>
            {
                entity.Move(direction, deltaTime);
                entity.Rotate(direction, deltaTime);
            }));
        }

        private void InstallRotate(IEntity entity)
        {
            entity.AddBehaviour<RotateBehaviour>();
            entity.AddRotateSpeed(new ReactiveVariable<float>(_angularSpeed));
        }
    }
}