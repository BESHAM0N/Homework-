using Atomic.Elements;
using Atomic.Entities;
using Game.Behavior;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private float _moveSpeed = 3;

        [SerializeField]
        private float _angularSpeed = 15;

        [SerializeField]
        private int _health = 3;

        [SerializeField]
        private GameObject _gameObject;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private WeaponEntity _hand;

        [SerializeField] private SceneEntity _initialTarget;
        [SerializeField] private float _cooldown;
       

        public override void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);

            entity.AddHandWeapon(_hand);
            
            entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));

            entity.AddRotateSpeed(new BaseFunction<float>(() => _angularSpeed * entity.GetHealth().Value));
            entity.AddHealth(new ReactiveVariable<int>(_health));

            entity.AddMoveAction(new BaseAction<Vector3, float>((direction, deltaTime) =>
            {
                entity.Move(direction, deltaTime);
                entity.Rotate(direction, deltaTime);
            }));

            entity.AddTarget(new ReactiveVariable<IEntity>(_initialTarget));

            var cooldown = new Cooldown(_cooldown);
            entity.AddFireCooldown(cooldown);
            entity.WhenFixedUpdate(cooldown.Tick);
            
            entity.AddBehaviour<DeathBehaviour>();
            entity.AddBehaviour<EnemyAttackBehavior>();
        }
    }
}