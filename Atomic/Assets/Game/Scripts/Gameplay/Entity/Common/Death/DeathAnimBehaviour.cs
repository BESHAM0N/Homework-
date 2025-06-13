using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class DeathAnimBehaviour : IEntityInit, IEntityDispose
    {
        private Animator _animator;
        private GameObject _gameObject;
        private IReactiveValue<int> _health;
        private bool _isDead;
        private float _deathTime;
        private float _deathDuration = 2f;
        
        private readonly string _animationName = "Death";

        public void Init(in IEntity entity)
        {
            _gameObject = entity.GetGameObject();
            _animator = entity.GetAnimator();
            _health = entity.GetHealth();

            if (_animator.runtimeAnimatorController != null)
            {
                foreach (var clip in _animator.runtimeAnimatorController.animationClips)
                {
                    if (clip.name == _animationName)
                        _deathDuration = clip.length;
                }
            }

            _health.Subscribe(OnHealthChanged);
            entity.WhenUpdate(Update);
        }

        private void Update(float obj)
        {
            if (_isDead && Time.time - _deathTime >= _deathDuration)
            {
                _gameObject.SetActive(false);
                _isDead = false;
            }
        }

        public void Dispose(in IEntity entity)
        {
            _health.Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int value)
        {
            if (value <= 0 && !_isDead)
            {
                _isDead = true;
                _deathTime = Time.time;
                _animator.SetTrigger(_animationName);
            }
        }
    }
}