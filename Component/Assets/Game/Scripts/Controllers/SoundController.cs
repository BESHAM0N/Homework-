using UnityEngine;

namespace Component
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private SoundComponent _soundComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private PushComponent _pushComponent;
        [SerializeField] private DropOffComponent _dropOffComponent;
        [SerializeField] private JumpComponent _jumpComponent;

        private void OnEnable()
        {
            _lifeComponent.OnHit += OnTakeDamage;
            _pushComponent.OnPush += OnPush;
            _dropOffComponent.OnDropOff += OnDrop;
            _jumpComponent.OnJump += OnJump;
        }

        private void OnDisable()
        {
            _lifeComponent.OnHit -= OnTakeDamage;
            _pushComponent.OnPush -= OnPush;
            _dropOffComponent.OnDropOff -= OnDrop;
            _jumpComponent.OnJump -= OnJump;
        }

        private void OnJump()
        {
            _soundComponent.PlaySound(SoundType.Jump);
        }

        private void OnDrop()
        {
            _soundComponent.PlaySound(SoundType.Toss);
        }

        private void OnTakeDamage()
        {
            _soundComponent.PlaySound(SoundType.TakeDamage);
        }

        private void OnPush()
        {
            _soundComponent.PlaySound(SoundType.Push);
        }
    }
}