using Atomic.Contexts;
using Game.Scripts.GameContext.Bullets;
using Game.Scripts.PlayerContext;
using SampleGame;
using UnityEngine;

namespace Game.Scripts.GameContext
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [SerializeField] private BulletSystemInstaller _bulletSystem;
        protected override void Install(IGameContext context)
        {
            _bulletSystem.Install(context);
        }
    }
}