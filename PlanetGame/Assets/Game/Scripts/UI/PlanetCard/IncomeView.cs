using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class IncomeView : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _progressBarBoard;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Image _coinIcon;

    private void Start()
    {
       gameObject.SetActive(false);
    }

    public void SetTimer(string timer)
    {
        _timerText.text = timer;
    }

    public void ShowProgressBar(bool show)
    {
        _progressBar.enabled = show;
        _progressBarBoard.enabled = show;
        _timerText.enabled = show;
        _coinIcon.gameObject.SetActive(!show);
    }
}