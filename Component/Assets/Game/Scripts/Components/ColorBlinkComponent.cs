using System.Collections;
using UnityEngine;

namespace Component
{
    public sealed class ColorBlinkComponent : MonoBehaviour
    {
        [SerializeField] private Color _blinkColor = Color.red;
        [SerializeField] private float _blinkDuration = 2f;
        [SerializeField] private float _blinkInterval = 0.2f;

        private SpriteRenderer _spriteRenderer;
        private Renderer _renderer;
        private Color _originalColor;
        private Coroutine _blinkRoutine;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            if (_spriteRenderer != null)
            {
                _originalColor = _spriteRenderer.color;
            }
        }

        public void StartBlink()
        {
            if (_blinkRoutine != null)
            {
                StopCoroutine(_blinkRoutine);
                ResetColor();
            }

            _blinkRoutine = StartCoroutine(BlinkRoutine());
        }

        private IEnumerator BlinkRoutine()
        {
            var elapsed = 0f;
            var isBlinkOn = false;

            while (elapsed < _blinkDuration)
            {
                isBlinkOn = !isBlinkOn;
                ApplyColor(isBlinkOn ? _blinkColor : _originalColor);
                yield return new WaitForSeconds(_blinkInterval);
                elapsed += _blinkInterval;
            }

            ResetColor();
            _blinkRoutine = null;
        }

        private void ApplyColor(Color color)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = color;
            }
            else if (_renderer != null)
            {
                _renderer.material.color = color;
            }
        }

        private void ResetColor()
        {
            ApplyColor(_originalColor);
        }
    }
}