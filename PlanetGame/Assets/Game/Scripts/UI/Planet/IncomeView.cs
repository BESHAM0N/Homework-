using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class IncomeView : MonoBehaviour
{
    [SerializeField] private GameObject _progressBar;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Image _coinIcon;

    public void SetTimer(string timer)
    {
        _timerText.text = timer;
    }
}