using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private GameObject _gameObject;
        private TriggerEventReceiver _trigger;
        private IValue<int> _damage;

        public void Init(in IEntity entity)
        {
            _gameObject = entity.GetGameObject();
            _trigger = entity.GetTrigger();
            _damage = entity.GetDamage();

            _trigger.OnEntered += OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity target) && target.TakeDamage(_damage.Value))
                GameObject.Destroy(_gameObject);
        }
    }
}