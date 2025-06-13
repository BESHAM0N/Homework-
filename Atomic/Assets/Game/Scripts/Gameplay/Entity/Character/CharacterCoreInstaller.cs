using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 1;
        [SerializeField] private int _rotateSpeed = 5;
        [SerializeField] private Transform _transform;
        [SerializeField] private int _health = 100;
        [SerializeField] private GameObject _character;
        [SerializeField] private TriggerEventReceiver _characterTrigger;
        [SerializeField] private WeaponEntity _pistolWeapon;
        [SerializeField] private InteractInstaller _interactInstaller;
        
        public override void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            
            entity.AddGameObject(_character);
            entity.AddTransform(_transform);
            entity.AddPistolWeapon(_pistolWeapon);
            entity.AddTrigger(_characterTrigger);
            
            InstallHealth(entity);
            InstallFire(entity);
            InstallRotate(entity);
            InstallMove(entity);
            _interactInstaller.Install(entity);
        }

        private void InstallMove(IEntity entity)
        {
            entity.AddBehaviour<MoveBehaviour>();
            entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddMoveAction(new BaseAction<Vector3, float>((direction, deltaTime) =>
            {
                if (entity.TryGetMoveCondition(out var condition) && !condition.Value)
                    return;

                var transform = entity.GetTransform();
                var speed = entity.GetMoveSpeed().Value;

                transform.position += direction * (speed * deltaTime);
            }));
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
        }

        private void InstallRotate(IEntity entity)
        {
            entity.AddBehaviour<RotateBehaviour>();
            entity.AddRotateSpeed(new BaseFunction<float>(() => _rotateSpeed));
            entity.AddRotateDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddRotateCondition(new AndExpression(entity.IsAlive));
        }

        private void InstallHealth(IEntity entity)
        {
            entity.AddDamageEvent(new BaseEvent<int>());
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddMaxHealth(_health);
            entity.AddBehaviour<DeathAnimBehaviour>();
            entity.AddBehaviour<DamageAnimBehaviour>();
        }

        private static void InstallFire(IEntity entity)
        {
            entity.AddFireEvent(new BaseEvent());
            entity.AddFireCondition(new BaseFunction<bool>(() =>
            {
                return HealthUseCase.IsAlive(entity)
                       && entity.GetPistolWeapon().GetFireCondition().Invoke()
                       && entity.GetFireRotateDirection().Value != Vector3.zero; 
            }));
            entity.AddFireAction(new CharacterFireAction(entity));
            entity.AddFireRotateDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddBehaviour<FireBehaviour>();
            entity.AddKill(new ReactiveVariable<int>(0));
        }
    }
}