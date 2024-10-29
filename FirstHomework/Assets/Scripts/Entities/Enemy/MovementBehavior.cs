using UnityEngine;

namespace ShootEmUp
{
    public class MovementBehavior
    {
        public bool IsPointReached { get; private set; }

        private Ship _ship;
        private Vector2 _destination;

        private const float MAGNITUDE_VALUE = 0.25f;

        public MovementBehavior(Ship ship)
        {
            _ship = ship;
        }

        public void SetDestination(Vector2 destination)
        {
            _destination = destination;
            IsPointReached = false;
        }

        public void Move()
        {
            var vector = _destination - _ship.Rigidbody.position;

            if (vector.magnitude <= MAGNITUDE_VALUE)
            {
                IsPointReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            var nextPosition = _ship.Rigidbody.position + direction * _ship.Speed;
            _ship.Move(nextPosition);
        }
    }
}