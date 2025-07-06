using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Context;
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
            _character = GameContext.Instance.GetCharacter();

            if (_character == null)
            {
                Debug.LogError("Character is not set in GameContext.");
                return;
            }

            _character.GetKill().Observe(OnKillChanged);
        }

        protected override void OnShow()
        {
            _character.GetKill().Observe(OnKillChanged);
        }

        protected override void OnHide()
        {
            _character.GetKill().Unsubscribe(OnKillChanged);
        }

        private void OnKillChanged(int kill)
        {
            _view.SetText(kill.ToString());
        }
    }
}