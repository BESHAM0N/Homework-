using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Game.Planets
{
    public class PlanetView : MonoBehaviour
    {
        public event UnityAction OnClicked
        {
            add { _button.onClick.AddListener(value); }
            remove { _button.onClick.RemoveListener(value); }
        }

        [SerializeField] private PriceView _priceView;
        [SerializeField] private IncomeView _incomeView;
        [SerializeField] private Image _planetIcon;
        [SerializeField] private Button _button;
        [SerializeField] private Image _lockIcon;

        public void SetPrice(string price)
        {
            _priceView.SetPrice(price);
        }

        public void SetTimer(string timer)
        {
            _incomeView.SetTimer(timer);
        }
        
        public void SetActiveLock(bool isUnlocked)
        {
            _lockIcon.gameObject.SetActive(!isUnlocked);
            _priceView.gameObject.SetActive(!isUnlocked);
            _incomeView.gameObject.SetActive(isUnlocked);
        }

        public void SetIcon(Sprite icon)
        {
            _planetIcon.sprite = icon;
        }
        
        public sealed class Pool : MonoMemoryPool<PlanetView>
        {
        }
    }
}