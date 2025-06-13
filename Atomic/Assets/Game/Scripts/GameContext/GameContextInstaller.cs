using System.Collections.Generic;
using Atomic.Contexts;
using Game.PlayerContext;
using SampleGame;
using UnityEngine;

namespace Game.Context
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [SerializeField] private BulletSystemInstaller _bulletSystem;
        protected override void Install(IGameContext context)
        {
            _bulletSystem.Install(context);
            context.AddPlayers(new Dictionary<int, IPlayerContext>());
            //context.AddPlayer(new PlayerContext.PlayerContext());
        }
    }
}