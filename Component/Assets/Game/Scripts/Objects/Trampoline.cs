using UnityEngine;

namespace Component
{
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField] private RepulsionComponent _repulsionComponent;
        [SerializeField] private SoundComponent _soundComponent;

        private void OnEnable()
        {
            _repulsionComponent.OnDropOff += OnDrop;
        }

        private void OnDisable()
        {
            _repulsionComponent.OnDropOff -= OnDrop;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {           
            _repulsionComponent.ExecuteAction();
        }

        private void OnDrop()
        {
            _soundComponent.PlaySound(SoundType.Trampline);
        }
    }
}