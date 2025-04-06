using System;
using UnityEngine;

namespace Component
{
    public class PushComponent : MonoBehaviour
    {
        [SerializeField] private float _pushForce = 10f; // Сила толкания
        [SerializeField] private float _pushRadius = 1f; // Радиус действия толчка
        [SerializeField] private LayerMask _pushLayer;

        private readonly AndCondition _andCondition = new();
        private Cooldawn _cooldown;

        private void Awake()
        {
            _cooldown = new Cooldawn(1f);
            _andCondition.AddCondition(() => _cooldown.IsReady());
        }

        public void ExecutePush()
        {
            if (!_andCondition.IsTrue())
                return;
            // Поиск всех коллайдеров в указанном радиусе, отфильтрованных по слою
            var colliders = Physics2D.OverlapCircleAll(transform.position, _pushRadius, _pushLayer);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject == gameObject)
                    continue;


                var rb = collider.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    Debug.Log("Pushing to " + collider.gameObject.name);
                    // Направление от текущего объекта к объекту-мишени
                    var pushDirection = ((Vector2)collider.transform.position - (Vector2)transform.position).normalized;
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