using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
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
            entity.AddCurrentWeapon(_pistolWeapon);
            entity.AddTrigger(_characterTrigger);
            
            InstallHealth(entity);
            InstallFire(entity);
            InstallRotate(entity);
            InstallMove(entity);
            _interactInstaller.Install(entity);
        }

        private void InstallMove(IEntity entity)
        {
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.WhenFixedUpdate(_ =>
            {
                var moveDir = entity.GetMoveDirection().Value;
                var fireDir = entity.GetFireRotateDirection().Value;

                if (moveDir != Vector3.zero)
                    entity.GetRotateDirection().Value = moveDir;
                else if (fireDir != Vector3.zero)
                    entity.GetRotateDirection().Value = fireDir;
            });
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
                       && entity.GetCurrentWeapon().GetFireCondition().Invoke()
                       && entity.GetFireRotateDirection().Value != Vector3.zero; 
            }));
            entity.AddFireAction(new FireAction(entity));
            entity.AddFireRotateDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddBehaviour(new FireBehaviour(new Cooldown(1f)));;
            entity.AddKill(new ReactiveVariable<int>(0));
        }
    }
}