using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private float moveDirection;        

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _player.Attack();

            moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 :
                Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

            if (moveDirection != 0)
                _player.Move(moveDirection);
        }
    }
}