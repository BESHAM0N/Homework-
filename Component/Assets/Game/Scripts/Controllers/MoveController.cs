using System;
using UnityEngine;

namespace Component
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        private MoveComponent _moveComponent;

        private void Start()
        {
            _moveComponent = _character.GetComponent<MoveComponent>();
        }

        private void Update()
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