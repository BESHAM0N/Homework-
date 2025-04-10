using UnityEngine;

namespace Component
{
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField] private DropOffComponent _dropOffComponent;
        [SerializeField] private SoundComponent _soundComponent;

        private void OnEnable()
        {
            _dropOffComponent.OnDropOff += OnDrop;
        }

        private void OnDisable()
        {
            _dropOffComponent.OnDropOff -= OnDrop;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {           
            _dropOffComponent.ExecuteDropOff();
        }

        private void OnDrop()
        {
            _soundComponent.PlaySound(SoundType.Trampline);
        }
    }
}