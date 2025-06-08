using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Scripts.GameContext;
using Game.UI;
using SampleGame;
using UnityEngine;

namespace Game.Presenters
{
    public class KillPresenter : Presenter
    {
        [SerializeField] private StatView _view;

        private IEntity _character;
        
        protected override void OnInit()
        {
            var gameContext = GameContext.Instance;
            _character = gameContext.GetPlayer().GetCharacter();
        }

        protected override void OnShow()
        {
            _character.GetKill().Observe(OnKillChanged);
        }

        protected override void OnHide()
        {
            _character.GetKill().Unsubscribe(OnKillChanged);
        }

        private void OnKillChanged(int health)
        {
            _view.SetText(health.ToString());
        }
    }
}