using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public sealed class IncomeView : MonoBehaviour
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Image _coinIcon;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void UpdateProgress(float remainingTime, float duration, string timer)
        {
            if (duration <= 0)
            {
                _progressSlider.value = _progressSlider.maxValue;
                return;
            }

            _progressSlider.maxValue = remainingTime;
            _progressSlider.value = _progressSlider.maxValue - duration;
            _timerText.text = timer;
        }

        public void ShowProgressBar(bool show)
        {
            _progressSlider.gameObject.SetActive(show);
            _timerText.enabled = show;
            _coinIcon.gameObject.SetActive(!show);
        }
    }
}