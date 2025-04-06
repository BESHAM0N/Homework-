using UnityEngine;
using Component;

namespace Component
{
    public class PatrollingComponent : MonoBehaviour
    {
        [SerializeField] private Transform pointA;             
        [SerializeField] private Transform pointB;             
        [SerializeField] private float reachThreshold = 0.1f;    
        [SerializeField] private MoveComponent moveComponent;    

        private Transform _currentTarget;

        private void Start()
        {
            if (pointA == null || pointB == null)
            {
                Debug.LogError("PatrollingComponent: Задайте обе точки патрулирования (pointA и pointB).");
                enabled = false;
                return;
            }

            // Выбираем стартовую цель – например, ту, которая дальше от текущей позиции
            float distanceToA = Vector2.Distance(transform.position, pointA.position);
            float distanceToB = Vector2.Distance(transform.position, pointB.position);
            _currentTarget = (distanceToA < distanceToB) ? pointB : pointA;
        }

        private void Update()
        {
            // Направление рассчитываем строго по двум точкам.
            Vector2 direction;
            if (_currentTarget == pointB)
            {
                direction = (pointB.position - pointA.position).normalized;
            }
            else
            {
                direction = (pointA.position - pointB.position).normalized;
            }

            moveComponent.SetDirection(direction);

            if (Vector2.Distance(transform.position, _currentTarget.position) < reachThreshold)
            {
                _currentTarget = (_currentTarget == pointA) ? pointB : pointA;
            }
        }
    }
}