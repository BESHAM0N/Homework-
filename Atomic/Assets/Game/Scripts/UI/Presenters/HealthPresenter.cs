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
            var gameContext = GameContext.Instance;
            _character = PlayersUseCase.GetCharacter(gameContext, 1);
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