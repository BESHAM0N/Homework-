using UnityEngine;

namespace Component
{
    public class RotateComponent : MonoBehaviour
    {
        [SerializeField] private Transform _rotationRoot;
        private Vector2 _rotateDirection = Vector2.right;

        public void SetDirection(Vector2 direction)
        {
            if (direction != Vector2.zero)
                _rotateDirection = direction;

            Rotate();
        }

        private void Rotate()
        {
            _rotationRoot.localRotation = _rotateDirection.x switch
            {
                < 0 => Quaternion.Euler(0, 180, 0),
                > 0 => Quaternion.Euler(0, 0, 0),
                _ => _rotationRoot.localRotation
            };
        }
    }
}