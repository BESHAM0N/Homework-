using UnityEngine;

namespace Component
{
    public sealed class ColorBlinkController : MonoBehaviour
    {
        [SerializeField] private ColorBlinkComponent _colorBlinkComponent;
        [SerializeField] private LifeComponent _lifeComponent;

        private void OnEnable()
        {
            _lifeComponent.OnHit += OnBlink;
        }

        private void OnDisable()
        {
            _lifeComponent.OnHit -= OnBlink;
        }

        private void OnBlink()
        {
            _colorBlinkComponent.StartBlink();
        }
    }
}