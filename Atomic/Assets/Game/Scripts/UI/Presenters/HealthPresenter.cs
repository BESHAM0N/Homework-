using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Context;
using Game.UI;
using SampleGame;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class HealthPresenter : Presenter
    {
        [SerializeField] private StatView _view;
        [SerializeField] private HealthScreen _healthScreen;
        
        private IEntity _character;
        private int _maxHealth;
        private HealthEffectHandler _effectHandler;
        
        protected override void OnInit()
        {
            _character = GameContext.Instance.GetCharacter();
            _maxHealth = _character.GetMaxHealth();
            var initial = _character.GetHealth().Value;

            _effectHandler = new HealthEffectHandler(_healthScreen, _maxHealth, initial);

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
            _effectHandler.UpdateHealth(health);
        }
    }
}