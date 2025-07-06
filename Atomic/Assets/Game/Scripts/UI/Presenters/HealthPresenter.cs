using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Context;
using SampleGame;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class HealthPresenter : Presenter
    {
        [SerializeField] private StatView _view;
        
        private IEntity _character;
        
        protected override void OnInit()
        {
            _character = GameContext.Instance.GetCharacter();
            _character.GetHealth().Observe(OnHealthChanged);
        }

        protected override void OnShow()
        {
            _character.GetHealth().Observe(OnHealthChanged);
        }

        protected override void OnHide()
        {
            _character.GetHealth().Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int health)
        {
            _view.SetText(health.ToString());
        }
    }
}