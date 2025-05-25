using Atomic.Elements;
using Atomic.Entities;
using Game.Behavior;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 1;
        [SerializeField] private int _rotateSpeed = 5;
        [SerializeField] private Transform _transform;
        [SerializeField] private int _health = 50;
        [SerializeField] private GameObject _character;
        [SerializeField] private WeaponEntity _pistolWeapon;
        public override void Install(IEntity entity)
        {
            entity.AddTransform(_transform);
            entity.AddGameObject(_character);
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddPistolWeapon(_pistolWeapon);
            
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
            
            entity.AddBehaviour<RotateBehaviour>();
            entity.AddRotateSpeed(new BaseFunction<float>(() => _rotateSpeed));
            entity.AddRotateDirection(new ReactiveVariable<Vector3>(Vector3.zero));
            entity.AddRotateCondition(new AndExpression(entity.IsAlive));
            
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
            
            entity.AddBehaviour<DeathBehaviour>();
        }
    }
}