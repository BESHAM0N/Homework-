using System;
using UnityEngine;

namespace Component
{
    public sealed class PushComponent : MonoBehaviour
    {
        public event Action OnPush;
        
        [SerializeField] private float _pushForce = 10f;
        [SerializeField] private float _pushRadius = 1f;
        [SerializeField] private LayerMask _pushLayer;
        [SerializeField] private float _cooldownDuration = 1f;

        private readonly AndCondition _andCondition = new();
        private Cooldawn _cooldown;

        private void Awake()
        {
            _cooldown = new Cooldawn(_cooldownDuration);
            _andCondition.AddCondition(() => _cooldown.IsReady());
        }

        public void ExecutePush()
        {
            if (!_andCondition.IsTrue())
                return;

            var colliders = Physics2D.OverlapCircleAll(transform.position, _pushRadius, _pushLayer);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == gameObject)
                    continue;


                var rb = collider.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    var pushDirection = ((Vector2)collider.transform.position - (Vector2)transform.position).normalized;
                    OnPush?.Invoke();
                    rb.AddForce(pushDirection * _pushForce, ForceMode2D.Impulse);
                }
            }

            _cooldown.ResetCooldown();
        }

        public void AddCondition(Func<bool> condition)
        {
            _andCondition.AddCondition(condition);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _pushRadius);
        }
    }
}