using UnityEngine;

namespace Component
{
    public sealed class SoundController : MonoBehaviour
    {
        [SerializeField] private SoundPresenter _soundPresenter;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField]  private RepulsionComponent _repulsionComponent;
        [SerializeField] private JumpComponent _jumpComponent;

        private void OnEnable()
        {
            _lifeComponent.OnHit += OnTakeDamage;
            _repulsionComponent.OnPush += OnPush;
            _repulsionComponent.OnDropOff += OnDrop;
            _jumpComponent.OnJump += OnJump;
        }

        private void OnDisable()
        {
            _lifeComponent.OnHit -= OnTakeDamage;
            _repulsionComponent.OnPush -= OnPush;
            _repulsionComponent.OnDropOff -= OnDrop;
            _jumpComponent.OnJump -= OnJump;
        }

        private void OnJump()
        {
            _soundPresenter.PlaySound(SoundType.Jump);
        }

        private void OnDrop()
        {
            _soundPresenter.PlaySound(SoundType.Toss);
        }

        private void OnTakeDamage()
        {
            _soundPresenter.PlaySound(SoundType.TakeDamage);
        }

        private void OnPush()
        {
            _soundPresenter.PlaySound(SoundType.Push);
        }
    }
}