using UnityEngine;

namespace Component
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private void FixedUpdate()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var direction = new Vector2(horizontal, 0);
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _moveComponent.SetDirection(direction);
        }
    }
}