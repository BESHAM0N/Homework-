using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class FireBehaviour : IEntityUpdate
    {
        private Cooldown _cooldown;

        public FireBehaviour(Cooldown cooldown)
        {
            _cooldown = cooldown;
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _cooldown.Tick(deltaTime);

            var direction = entity.GetFireRotateDirection().Value;
            if (direction != Vector3.zero && entity.GetFireCondition().Invoke() && _cooldown.IsExpired())
            {
                entity.GetFireAction().Invoke();
                _cooldown.Reset();
            }
        }
    }
}