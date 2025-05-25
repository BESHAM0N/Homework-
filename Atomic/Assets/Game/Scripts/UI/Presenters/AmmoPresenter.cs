using Atomic.Presenters;
using Game.Gameplay;
using SampleGame;
using UnityEngine;
using Game.UI;

namespace Game.Presenters
{
    public sealed class AmmoPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IWeaponEntity _weapon;

        public void SetWeapon(IWeaponEntity weapon)
        {
            _weapon = weapon;
        }

        protected override void OnShow()
        {
            _weapon.GetAmmo().Observe(OnAmmoChanged);
            OnAmmoChanged(_weapon.GetAmmo().Value);
        }

        protected override void OnHide()
        {
            _weapon.GetAmmo().Unsubscribe(OnAmmoChanged);
        }

        private void OnAmmoChanged(int ammo)
        {
            _view.SetText(ammo.ToString());
        }
    }
}