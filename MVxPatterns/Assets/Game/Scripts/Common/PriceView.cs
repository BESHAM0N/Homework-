using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public sealed class PriceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _priceIcon;

        public void SetPrice(string price)
        {
            _priceText.text = price;
        }
    }
}