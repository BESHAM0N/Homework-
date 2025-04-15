using UnityEngine;
using UnityEngine.Serialization;

namespace Component
{
    public sealed class ColorBlinkController : MonoBehaviour
    {
        [SerializeField] private ColorBlinkPresenter _colorBlinkPresenter;
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
            _colorBlinkPresenter.StartBlink();
        }
    }
}