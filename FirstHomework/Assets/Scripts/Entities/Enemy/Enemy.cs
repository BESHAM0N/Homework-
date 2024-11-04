using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : MonoBehaviour
    {
        public int Health => _enemyShip.Health;
        public Vector2 Position
        {
            set => transform.position = value;
        }

        public Ship Ship => _enemyShip;

        [SerializeField] private Ship _enemyShip;

        private Ship _target;        
        private MovementBehavior _movementBehavior;
        private AttackBehavior _attackBehavior;

        private void Awake()
        {           
            _movementBehavior = new MovementBehavior(_enemyShip);            
            SetTarget();           
        }        

        private void SetTarget()
        {
            var obj = GameObject.FindGameObjectWithTag("Player");
            if (obj != null)
                _target = obj.GetComponent<Ship>();
            else
                Debug.Log("Player not found");
        }

        private void FixedUpdate()
        {
            if (_target != null && _target.Health > 0)
            {
                if (_movementBehavior.IsPointReached)
                    _attackBehavior.Attack(_target);
                else
                    _movementBehavior.Move();
            }
        }

        public void Activate(Vector2 destination)
        {           
            _enemyShip.ResetShip();
            _movementBehavior.SetDestination(destination);
            _attackBehavior = new AttackBehavior(_enemyShip);           
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

        public void ResetEnemy()
        {
            _enemyShip.ResetShip();
            SetTarget();
            gameObject.SetActive(true);
        }
    }
}