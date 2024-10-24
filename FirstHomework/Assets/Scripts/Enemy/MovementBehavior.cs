using UnityEngine;

namespace ShootEmUp
{
    public class MovementBehavior
    {
        public bool IsPointReached { get; private set; }

        private Rigidbody2D _rigidbody;
        private float _speed;
        private Vector2 _destination;

        public MovementBehavior(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void SetDestination(Vector2 destination)
        {
            _destination = destination;
            IsPointReached = false;
        }

        public void Move(Vector2 targetPosition)
        {
            var vector = _destination - _rigidbody.position;

            if (vector.magnitude <= 0.25f)
            {
                IsPointReached = true;
                Debug.Log($"IsPointReached: {IsPointReached}");
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            var nextPosition = _rigidbody.position + direction * _speed;
            _rigidbody.MovePosition(nextPosition);
        }
    }
}