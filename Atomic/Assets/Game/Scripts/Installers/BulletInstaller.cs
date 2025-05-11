using Atomic.Elements;
using Atomic.Entities;
using Game.Behavior;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private int _damage = 3;
        [SerializeField] private TriggerEventReceiver _trigger;
        public override void Install(IEntity entity)
        {
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(transform.forward));
            entity.AddTrigger(_trigger);
            
            entity.WhenFixedUpdate(entity.MoveSelf);
            entity.AddBehaviour<BulletCollisionBehaviour>();
            entity.AddDamage(new Const<int>(_damage));
        }
    }
}