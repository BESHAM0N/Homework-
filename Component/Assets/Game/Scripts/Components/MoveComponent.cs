using System;
using UnityEngine;

namespace Component
{
    public sealed class MoveComponent : MonoBehaviour
    {
        public event Action<Vector2> OnRotate;
        
        [SerializeField] private float _speed = 5f;
        [SerializeField] private bool _canMove = true;
        [SerializeField] private MovementType _movementType = MovementType.Horizontal;
        private Vector2 _direction;
        private readonly AndCondition _andCondition = new();

        public void SetDirection(Vector2 newDirection)
        {
            if (_movementType == MovementType.Horizontal)
            {
                _direction = new Vector2(newDirection.x, 0);
                OnRotate?.Invoke(_direction);
            }
            else 
            {
                _direction = new Vector2(0, newDirection.y);
            }
        }

        private void FixedUpdate()
        {
            Move();
        }
      
        private void Move()
        {
            if (!_canMove || !_andCondition.IsTrue())
                return;
            
            transform.Translate(_direction.normalized * _speed * Time.fixedDeltaTime, Space.World);
        }
        
        public void AddCondition(Func<bool> condition)
         {
            _andCondition.AddCondition(condition);
        }
    }
}