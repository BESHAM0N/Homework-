using System;
using UnityEngine;

namespace Component
{
    public sealed class DropOffComponent : MonoBehaviour
    {
        public event Action OnDropOff;
        
        [SerializeField] private float _dropForce = 10f; 
        [SerializeField] private float _dropRadius = 2f;
        [SerializeField] private LayerMask _dropLayer;
        [SerializeField] private float _cooldownDuration = 0.5f;

        private readonly AndCondition _andCondition = new();
        private Cooldawn _cooldown;

        private void Awake()
        {
            _cooldown = new Cooldawn(_cooldownDuration);
            _andCondition.AddCondition(() => _cooldown.IsReady());
        }

        public void ExecuteDropOff()
        {
            if (!_andCondition.IsTrue())
                return;

            var colliders = Physics2D.OverlapCircleAll(transform.position, _dropRadius, _dropLayer);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == gameObject)
                    continue;

                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    OnDropOff?.Invoke();
                    rb.AddForce(Vector2.up * _dropForce, ForceMode2D.Impulse);
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
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _dropRadius);
        }
    }
}