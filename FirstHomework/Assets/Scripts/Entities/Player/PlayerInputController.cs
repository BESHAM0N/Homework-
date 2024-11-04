using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {        
        [SerializeField] private Ship _playerShip;
        private float _moveDirection;        

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

            _moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 :
                Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

            if (_moveDirection != 0)
            {
                _playerShip.Move(new Vector2(_moveDirection, 0));
            }
        }
    }
}