using System;
using Game.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Views
{
    public class PlanetCard : MonoBehaviour, IDisposable
    {
        public event UnityAction OnClicked
        {
            add { _button.onClick.AddListener(value); }
            remove { _button.onClick.RemoveListener(value); }
        }

        public event Action OnClickedMoneyIcon;
        
        public Vector3 MoneyIconPosition => _moneyButton.transform.position;

        [SerializeField] private PriceView _priceView;
        [SerializeField] private IncomeView _incomeView;
        [SerializeField] private Image _planetIcon;
        [SerializeField] private Button _button;
        [SerializeField] private Image _lockIcon;
        
        [SerializeField] private Button _moneyButton;

        private void Start()
        {
            _moneyButton.onClick.AddListener(OnClickedMoney);
        }
        
        public void Dispose()
        {
            _moneyButton.onClick.RemoveListener(OnClickedMoney);
        }

        public void SetPrice(string price)
        {
            _priceView.SetPrice(price);
        }
        
        public void SetTimer(float  remainingTime, float  duration, string timer)
        {
            _incomeView.UpdateProgress(remainingTime, duration, timer);
            _incomeView.ShowProgressBar(true);
        }
        
        public void SetProgressBar(bool show)
        {
            _incomeView.ShowProgressBar(show);
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

        private void OnClickedMoney()
        {
            OnClickedMoneyIcon!.Invoke();
        }        
    }
}