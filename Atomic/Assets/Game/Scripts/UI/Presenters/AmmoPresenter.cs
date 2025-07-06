using Atomic.Presenters;
using Game.Context;
using Game.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class AmmoPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IWeaponEntity _weapon;

        protected override void OnInit()
        {
            _weapon = GameContext.Instance.GetCharacter().GetCurrentWeapon();
            OnAmmoChanged();
        }

        protected override void OnShow()
        {
            _weapon.GetAmmo().OnStateChanged += OnAmmoChanged;
        }

        protected override void OnHide()
        {
            _weapon.GetAmmo().OnStateChanged -= OnAmmoChanged;
        }

        private void OnAmmoChanged()
        {
            _view.SetText(_weapon.GetAmmo().GetCount().ToString());
        }
    }
}