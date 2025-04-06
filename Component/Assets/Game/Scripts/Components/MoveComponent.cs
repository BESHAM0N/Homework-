using System;
using UnityEngine;

namespace Component
{
    public class MoveComponent : MonoBehaviour
    {
        public Action<Vector2> OnRotate;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private bool _canMove = true;
        // Флаги управления по осям
        [SerializeField] private bool controlHorizontal = true;
        [SerializeField] private bool controlVertical;

        // Вектор направления задается через SetDirection.
        private Vector2 _moveDirection;
        private readonly AndCondition _andCondition = new();

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (!_canMove || !_andCondition.IsTrue())
                return;

            // Берем текущую скорость
            Vector2 currentVel = _rigidbody.velocity;
            // Начинаем с текущего значения, чтобы сохранить ту часть, которую не контролируем
            Vector2 targetVel = currentVel;

            if (controlHorizontal)
            {
                // Задаем горизонтальную скорость
                targetVel.x = _moveDirection.x * _speed;
            }
            if (controlVertical)
            {
                // Задаем вертикальную скорость
                targetVel.y = _moveDirection.y * _speed;
            }

            _rigidbody.velocity = targetVel;
        }

        /// <summary>
        /// Задает направление движения.
        /// Для игрока можно передавать только горизонтальную составляющую,
        /// для объектов с полным контролем — направление может быть произвольным.
        /// </summary>
        public void SetDirection(Vector2 direction)
        {
            _moveDirection = direction.normalized;
            OnRotate?.Invoke(_moveDirection);
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