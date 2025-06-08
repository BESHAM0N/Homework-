using Atomic.Elements;
using Atomic.Presenters;
using Game.Gameplay;
using Game.Scripts.GameContext;
using SampleGame;
using UnityEngine;
using Game.UI;

namespace Game.Presenters
{
    public sealed class AmmoPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IWeaponEntity _weapon;
        protected override void OnInit()
        {
            var gameContext = GameContext.Instance;
            _weapon = gameContext.GetPlayer().GetCharacter().GetPistolWeapon();
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