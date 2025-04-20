using UnityEngine;

namespace Component
{
    public sealed class SoundPresenter : MonoBehaviour
    {
        [SerializeField] private SoundComponent _soundComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField]  private RepulsionComponent _repulsionComponent;
        [SerializeField] private JumpComponent _jumpComponent;

        private void OnEnable()
        {
            _lifeComponent.OnHit += OnTakeDamage;
            _repulsionComponent.OnRepulsion += OnRepulsion;
            _repulsionComponent.OnRepulsion += OnToss;
            _jumpComponent.OnJump += OnJump;
        }

        private void OnDisable()
        {
            _lifeComponent.OnHit -= OnTakeDamage;
            _repulsionComponent.OnRepulsion -= OnRepulsion;
            _repulsionComponent.OnRepulsion -= OnToss;
            _jumpComponent.OnJump -= OnJump;
        }

        private void OnJump()
        {
            _soundComponent.PlaySound(SoundType.Jump);
        }

        private void OnToss()
        {
            _soundComponent.PlaySound(SoundType.Toss);
        }

        private void OnTakeDamage()
        {
            _soundComponent.PlaySound(SoundType.TakeDamage);
        }

        private void OnRepulsion()
        {
            _soundComponent.PlaySound(SoundType.Push);
        }
    }
}