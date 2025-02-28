using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class IncomeView : MonoBehaviour
{
    [SerializeField] private GameObject _progressBar;
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
        _progressBar.SetActive(show);
        _coinIcon.gameObject.SetActive(!show);
    }
}