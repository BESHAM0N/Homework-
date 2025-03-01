using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
   [SerializeField] private TMP_Text _currencyText;

   public void SetMoney(string currency)
   {
      _currencyText.text = currency;
   }
}
