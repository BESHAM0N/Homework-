using UnityEngine;

namespace Component
{
    public sealed class Lava : MonoBehaviour
    {
        [SerializeField] private SoundPresenter _soundPresenter;
        [SerializeField] private int _damage = 1000;
       
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable proxy))
            {
                _soundPresenter.PlaySound(SoundType.Lava);
                proxy.TakeDamage(_damage);
            }
        }
    }
}