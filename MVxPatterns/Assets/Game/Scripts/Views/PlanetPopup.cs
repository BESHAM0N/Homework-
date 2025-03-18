using Game.Presenters;
using Modules.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Views
{
    public class PlanetPopup : View
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _planetName;
        [SerializeField] private TMP_Text _population;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _income;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private TMP_Text _upgradePrice;
        
        [SerializeField] private GameObject _upgradeButtonPanel;
        [SerializeField] private GameObject _maxLevelPanel;

        [Inject] private IPlanetPopupPresenter _presenter;
        
        protected override void OnShow()
        {
            _presenter.OnStateChanged += OnStateChanged;
            _upgradeButton.onClick.AddListener(_presenter.Upgrade);
            _closeButton.onClick.AddListener(OnCloseClicked);
            OnStateChanged();
        }

        protected override void OnHide()
        {
            _presenter.OnStateChanged -= OnStateChanged;
            _upgradeButton.onClick.RemoveListener(_presenter.Upgrade);
            _closeButton.onClick.RemoveListener(OnCloseClicked);
        }

        private void OnStateChanged()
        {
            _planetName.text = _presenter.PlanetName;
            _population.text = _presenter.Population;
            _level.text = _presenter.LevelText;
            _income.text = _presenter.Income;
            _icon.sprite = _presenter.Icon;
            _upgradeButton.interactable = _presenter.CanUpgrade();
            _upgradePrice.text = _presenter.UpgradePrice;
            OnShowMaxLevelButton();
        }

        private void OnShowMaxLevelButton()
        {
            var isMaxLevel = _presenter.PlanetMaxLevel;
            _upgradeButtonPanel.SetActive(!isMaxLevel);
            _maxLevelPanel.SetActive(isMaxLevel);
        }

        private void OnCloseClicked()
        {
            Hide();
        }
    }
}