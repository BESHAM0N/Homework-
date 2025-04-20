using System;
using UnityEngine;

namespace Component
{
    public class RepulsionComponent : MonoBehaviour
    {
        public event Action OnRepulsion;

        [SerializeField] private float _force = 10f;
        [SerializeField] private float _radius = 1f;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private float _pushCooldownDuration = 1f;

        private readonly AndCondition _andCondition = new();
        private Cooldawn _cooldown;

        private void Awake()
        {
            _cooldown = new Cooldawn(_pushCooldownDuration);
            _andCondition.AddCondition(() => _cooldown.IsReady());
        }

        public void ExecuteAction(Vector2 direction)
        {
            if (!_andCondition.IsTrue())
                return;

            var colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layer);

            foreach (var collider in colliders)
            {
                if (collider.gameObject == gameObject)
                    continue;

                var rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    if (direction == Vector2.zero)
                        direction = ((Vector2)collider.transform.position - (Vector2)transform.position).normalized;
                    
                    OnRepulsion?.Invoke();
                    rb.AddForce(direction * _force, ForceMode2D.Impulse);
                }
            }

            _cooldown.ResetCooldown();
        }

        public void AddCondition(Func<bool> condition)
        {
            _andCondition.AddCondition(condition);
        }
    }
}