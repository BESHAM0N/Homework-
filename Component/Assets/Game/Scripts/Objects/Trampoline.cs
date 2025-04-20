using UnityEngine;

namespace Component
{
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField] private RepulsionComponent _repulsionComponent;
        [SerializeField] private SoundComponent _soundComponent;
        [SerializeField] private Vector2 _vector2;

        private void OnEnable()
        {
            _repulsionComponent.OnRepulsion += OnDrop;
        }

        private void OnDisable()
        {
            _repulsionComponent.OnRepulsion -= OnDrop;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {           
            _repulsionComponent.ExecuteAction(_vector2);
        }

        private void OnDrop()
        {
            _soundComponent.PlaySound(SoundType.Trampline);
        }
    }
}