using Atomic.Elements;
using Atomic.Entities;
using Game.Behavior;
using SampleGame;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private float _moveSpeed = 10;
        [SerializeField] private int _rotateSpeed = 15;
        [SerializeField] private Transform _transform;
        [SerializeField] private int _health = 10;
        [SerializeField] private GameObject _character;
        [SerializeField] private WeaponEntity _pistolWeapon;
        public override void Install(IEntity entity)
        {
            entity.AddTransform(_transform);
            entity.AddGameObject(_character);
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddMoveSpeed(new ReactiveVariable<float>(_moveSpeed));
            entity.AddPistolWeapon(_pistolWeapon);
            
            entity.AddFireEvent(new BaseEvent());
            entity.AddFireCondition(new BaseFunction<bool>(() => HealthUseCase.IsAlive(entity)));
            entity.AddFireAction(new CharacterFireAction(entity));
            
            entity.AddRotateSpeed(new BaseFunction<float>(() => _rotateSpeed * entity.GetHealth().Value));
            // entity.AddMoveAction(new BaseAction<Vector3, float>((direction, deltaTime) =>
            // {
            //     entity.
            // }))
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            entity.AddBehaviour<DeathBehaviour>();
        }
    }
}