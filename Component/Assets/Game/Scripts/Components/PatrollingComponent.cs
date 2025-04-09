using UnityEngine;

namespace Component
{
    public sealed class PatrollingComponent : MonoBehaviour
    {
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;
        [SerializeField] private float _reachThreshold = 0.1f;
        [SerializeField] private MoveComponent _moveComponent;

        private Transform _currentTarget;

        private void Start()
        {
            if (_pointA == null || _pointB == null)
            {
                enabled = false;
                return;
            }

            var distanceToA = Vector2.Distance(transform.position, _pointA.position);
            var distanceToB = Vector2.Distance(transform.position, _pointB.position);
            _currentTarget = (distanceToA < distanceToB) ? _pointB : _pointA;
        }

        private void Update()
        {
            Vector2 direction;
            if (_currentTarget == _pointB)
            {
                direction = (_pointB.position - _pointA.position).normalized;
            }
            else
            {
                direction = (_pointA.position - _pointB.position).normalized;
            }

            _moveComponent.SetDirection(direction);

            if (Vector2.Distance(transform.position, _currentTarget.position) < _reachThreshold)
            {
                _currentTarget = (_currentTarget == _pointA) ? _pointB : _pointA;
            }
        }
    }
}