using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {        
        [SerializeField] private Ship _playerShip;
        private float moveDirection;        

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var direction = _playerShip.FirePoint.rotation * Vector3.up;                    
                _playerShip.Attack(direction);
            }

            moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 :
                Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

            if (moveDirection != 0)
            {
                var direction = new Vector2(moveDirection, 0);
                var moveStep = direction * Time.fixedDeltaTime * _playerShip.Speed;
                var targetPosition = _playerShip.Rigidbody.position + moveStep;
                _playerShip.Move(targetPosition);
            }
        }
    }
}