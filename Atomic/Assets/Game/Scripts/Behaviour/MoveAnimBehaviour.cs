using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class MoveAnimBehaviour : IEntityInit, IEntityDispose
    {
        private Animator _animator;
        private IReactiveValue<Vector3> _moveDirection;
        private readonly int _isMovingHash;

        public MoveAnimBehaviour(string isMovingHash)
        {
            _isMovingHash = Animator.StringToHash(isMovingHash);
        }
        
        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _moveDirection = entity.GetMoveDirection();
            _moveDirection.Observe(OnMoveDirectionChanged);
        }

        public void Dispose(in IEntity entity)
        {
            _moveDirection.Unsubscribe(OnMoveDirectionChanged);
        }

        private void OnMoveDirectionChanged(Vector3 direction)
        {
            Debug.Log($"OnMoveDirectionChanged,direction: {direction}");
            _animator.SetBool(_isMovingHash, direction != Vector3.zero);
        }
    }
}