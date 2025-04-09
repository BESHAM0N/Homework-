using UnityEngine;

namespace Component
{
    public sealed class DamageableProxy : MonoBehaviour, IDamageable
    {
        [SerializeField] private LifeComponent _lifeComponent;
        
        public void TakeDamage(int damage)
        {
            _lifeComponent.TakeDamage(damage);
        }
    }
}