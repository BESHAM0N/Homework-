using System;
using UnityEngine;

namespace Component
{
    public class RepulsionComponent : MonoBehaviour
    {
        [SerializeField] private RepulsionType _repulsionType = RepulsionType.Push;
        [SerializeField] private DropOffType _dropOffType = DropOffType.Up;

        [Header("Параметры для DropOff")] [SerializeField]
        private float _dropForce = 10f;

        [SerializeField] private float _dropRadius = 2f;
        [SerializeField] private LayerMask _dropLayer;
        [SerializeField] private float _dropCooldownDuration = 0.5f;

        [Header("Параметры для Push")] [SerializeField]
        private float _pushForce = 10f;

        [SerializeField] private float _pushRadius = 1f;
        [SerializeField] private LayerMask _pushLayer;
        [SerializeField] private float _pushCooldownDuration = 1f;

        private readonly AndCondition _andCondition = new();
        private Cooldawn _cooldown;

        public event Action OnDropOff;
        public event Action OnPush;

        private void Awake()
        {
            var cooldownDuration =
                _repulsionType == RepulsionType.DropOff ? _dropCooldownDuration : _pushCooldownDuration;
            _cooldown = new Cooldawn(cooldownDuration);
            _andCondition.AddCondition(() => _cooldown.IsReady());
        }

        public void SetRepulsionType(RepulsionType repulsionType)
        {
            _repulsionType = repulsionType;
        }

        public void ExecuteAction()
        {
            if (!_andCondition.IsTrue())
                return;

            if (_repulsionType == RepulsionType.DropOff)
            {
                var colliders = Physics2D.OverlapCircleAll(transform.position, _dropRadius, _dropLayer);
                foreach (var collider in colliders)
                {
                    if (collider.gameObject == gameObject)
                        continue;

                    var rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        OnDropOff?.Invoke();
                        
                        switch (_dropOffType)
                        {
                            case DropOffType.Up:
                                rb.AddForce(Vector2.up * _dropForce, ForceMode2D.Impulse);
                                break;
                            case DropOffType.Rigth:
                                rb.AddForce(Vector2.right * _dropForce, ForceMode2D.Impulse);
                                break;
                        }
                    }
                }
            }
            else
            {
                var colliders = Physics2D.OverlapCircleAll(transform.position, _pushRadius, _pushLayer);
                foreach (var collider in colliders)
                {
                    if (collider.gameObject == gameObject)
                        continue;

                    var rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        var pushDirection = (((Vector2)collider.transform.position - (Vector2)transform.position)
                            .normalized);
                        OnPush?.Invoke();
                        rb.AddForce(pushDirection * _pushForce, ForceMode2D.Impulse);
                    }
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