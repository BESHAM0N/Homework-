using Atomic.Entities;
using Game.Behavior;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAnimInstaller : SceneEntityInstaller
    {
        private const string fireEvent = "fire_event";

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimationEventReceiver _animationReceiver;
        
        [SerializeField]
        private string _isMovingKey = "IsMoving";

        public override void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddBehaviour(new MoveAnimBehaviour(_isMovingKey));
            entity.AddBehaviour<AttackAnimBehaviour>();
            entity.AddBehaviour<DeathAnimBehaviour>();
        }
    }
}