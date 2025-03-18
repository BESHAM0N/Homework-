using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Views
{
    public class MoneyView: MonoBehaviour
    {
        public Vector3 MoneyIconPosition => _moneyIcon.transform.position;
        
        [SerializeField] private TMP_Text _currencyText;
        [SerializeField] private Transform _moneyIcon;
        private int _currentValue;

        public void SetMoney(string currency)
        {
            _currencyText.text = currency;
        }

        public void UpdateMoney(string currency)
        {
            if (!int.TryParse(currency, out int newValue))
                newValue = 0;
            
            DOTween.Kill(this);

            var duration = 0.5f;
            DOTween.To(() => _currentValue, x =>
                {
                    _currentValue = x;
                    _currencyText.text = x.ToString();
                }, newValue, duration)
                .SetId(this);
        }
    }
}