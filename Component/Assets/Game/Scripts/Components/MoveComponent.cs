using System;
using UnityEngine;

namespace Component
{
    public enum MovementType
    {
        Horizontal,
        Vertical
    }

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


// using System;
// using UnityEngine;
//
// namespace Component
// {
//     public class MoveComponent : MonoBehaviour
//     {
//         public Action<Vector2> OnRotate;
//         [SerializeField] private Rigidbody2D _rigidbody;
//         [SerializeField] private float _speed;
//         [SerializeField] private bool _canMove = true;
//         
//         private Vector3 _moveDirection;
//         private readonly AndCondition _andCondition = new();
//
//         private void FixedUpdate()
//         {
//             Move();
//         }
//
//         // private void Move()
//         // {
//         //     if (!_canMove || !_andCondition.IsTrue())
//         //         return;
//         //    
//         //     var currentX = _rigidbody.velocity.x;
//         //     var targetX = _moveDirection.x * _speed;
//         //     var newX = Mathf.Lerp(currentX, targetX, 0.1f); 
//         //
//         //     _rigidbody.velocity = new Vector2(newX, _rigidbody.velocity.y);
//         // }
//         
//         private void Move()
//         {
//             if (!_canMove || !_andCondition.IsTrue())
//                 return;
//
//             // // Получаем текущую скорость
//             // Vector2 currentVel = _rigidbody.velocity;
//             // // Целевая скорость — это направление (с учетом вертикали) умноженное на скорость
//             // Vector2 targetVel = _moveDirection * _speed;
//             // // Интерполируем текущую скорость к целевой по обоим осям
//             // Vector2 newVel = Vector2.Lerp(currentVel, targetVel, 0.1f);
//             // _rigidbody.velocity = newVel;
//         }
//
//         public void SetDirection(Vector2 direction)
//         {
//             _moveDirection = direction;
//             OnRotate?.Invoke(_moveDirection);
//         }
//         
//         public void AddCondition(Func<bool> condition)
//         {
//             _andCondition.AddCondition(condition);
//         }
//     }
// }