using System;
using UnityEngine;

namespace Component
{
    public class JumpComponent : MonoBehaviour
    {
        public bool OnGround => _onGround;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _jumpCooldown = 1f;

        private bool _onGround = true;
        private readonly AndCondition _andCondition = new();
        private Cooldawn _cooldown;

        private void Awake()
        {
            _cooldown = new Cooldawn(_jumpCooldown);
            _andCondition.AddCondition(() => _cooldown.IsReady());
            _andCondition.AddCondition(() => _onGround);
        }

        public void ExecuteJump()
        {
            if (!_andCondition.IsTrue())
                return;

            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _cooldown.ResetCooldown();
            _onGround = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                _onGround = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                _onGround = false;
        }

        public void AddCondition(Func<bool> condition)
        {
            _andCondition.AddCondition(condition);
        }
    }
}