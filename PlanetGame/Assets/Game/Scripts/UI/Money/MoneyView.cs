using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class MoneyView : MonoBehaviour
{
    public event UnityAction OnClicked
    {
        add { _button.onClick.AddListener(value); }
        remove { _button.onClick.RemoveListener(value); }
    }
    
    [SerializeField] private Button _button;
    [Inject] private TMP_Text _allMoneyText;
    
    public void SetAllMoneyText(string amount)
    {
        _allMoneyText.text = amount;
    }
}
