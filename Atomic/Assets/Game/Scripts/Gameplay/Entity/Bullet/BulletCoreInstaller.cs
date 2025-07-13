using Atomic.Elements;
using Atomic.Entities;
using Game.Context;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 45;
        [SerializeField] private int _damage = 3;
        [SerializeField] private TriggerEventReceiver _trigger; 
        [SerializeField] private float _lifetime = 3;
        public override void Install(IEntity entity)
        {
            GameContext gameContext = GameContext.Instance;
            
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.AddDamage(new Const<int>(_damage));
            entity.AddLifeTime(new Cooldown(_lifetime, _lifetime));
            entity.AddDestroyAction(new BaseAction(() => SpawnBulletUseCase.UnspawnBullet(gameContext, entity)));
            
            entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
            entity.AddMoveDirection(new ReactiveVariable<Vector3>(transform.forward));
            entity.AddTrigger(_trigger);
            
            entity.WhenFixedUpdate(entity.MoveSelf);
            entity.AddBehaviour<BulletLifetimeBehaviour>();
            entity.AddBehaviour<BulletCollisionBehaviour>();
        }
    }
}