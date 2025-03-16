using TMPro;
using UnityEngine;

namespace Game.Views
{
    public class MoneyView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyText;

        public void SetMoney(string currency)
        {
            //TODO: Анимация счетчика, пополннение монет  
            _currencyText.text = currency;
        }
    }
}