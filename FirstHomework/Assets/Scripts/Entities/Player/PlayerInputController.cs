using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {        
        [SerializeField] private Ship _playerShip;
        private Vector2 _moveDirection;        

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerShip.Attack(Vector3.up);
            }

            var horizontal = Input.GetKey(KeyCode.LeftArrow) ? -1 :
                Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

            _moveDirection = new Vector2(horizontal, 0);

            if (_moveDirection != Vector2.zero)
            {
                _playerShip.Move(_moveDirection);
            }
        }
    }
}