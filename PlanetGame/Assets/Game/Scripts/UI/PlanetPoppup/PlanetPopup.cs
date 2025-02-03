using Modules.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Planets
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
            _level.text = $"Level: {_presenter.CurrentLevel} / {_presenter.MaxLevel}";
            _income.text = $"Income: {_presenter.Income} / sec";
            _icon.sprite = _presenter.Icon;
            _upgradeButton.interactable = _presenter.CanUpgrade();
            _upgradePrice.text = _presenter.UpgradePrice;
        }

        private void OnCloseClicked()
        {
            Hide();
        }
    }
}