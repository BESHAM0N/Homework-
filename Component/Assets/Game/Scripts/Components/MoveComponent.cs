using System;
using UnityEngine;

namespace Component
{
    public class MoveComponent : MonoBehaviour
    {
        public Action<Vector2> OnRotate;
        [SerializeField] private float speed = 5f;
        [SerializeField] private bool _canMove = true;
        [SerializeField] private MovementType movementType = MovementType.Horizontal;
        private Vector2 direction;
        private readonly AndCondition _andCondition = new();

        public void SetDirection(Vector2 newDirection)
        {
            if (movementType == MovementType.Horizontal)
            {
                direction = new Vector2(newDirection.x, 0);
                OnRotate?.Invoke(direction);
            }
            else 
            {
                direction = new Vector2(0, newDirection.y);
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
            
            transform.Translate(direction.normalized * speed * Time.fixedDeltaTime, Space.World);
        }
        
        public void AddCondition(Func<bool> condition)
         {
            _andCondition.AddCondition(condition);
        }
    }
}