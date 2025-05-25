using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ProjectileVisualInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private TrailView _trailView;
        [SerializeField] private ParticleSystem _fireVfx;
        [SerializeField] private AudioSource _fireAudioSource;
        
        public override void Install(IEntity entity)
        {
            entity.WhenEnable(() => _trailView.Show());
            entity.WhenDisable(() => _trailView.Hide());
            entity.GetFireEvent().Subscribe(()=>
            {
                _fireVfx.Play();
                _fireAudioSource.Play();
            });
        }
    }
}