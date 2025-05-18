using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class FireBehaviour : IEntityUpdate
    {
        private Cooldown _cooldown = new Cooldown(1f);
        
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _cooldown.Tick(deltaTime);

            var direction = entity.GetRotateDirection().Value;
            if (direction != Vector3.zero && entity.GetFireCondition().Invoke() && _cooldown.IsExpired())
            {
                entity.GetFireAction().Invoke();
                _cooldown.Reset();
            }
        }
    }
}