using Atomic.Contexts;
using Atomic.Entities;
using Game.Context;
using Game.Controllers;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.PlayerContext
{
    public class PlayerContextInstaller : SceneContextInstaller<IPlayerContext>
    {
        [SerializeField] private SceneEntity _character;
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _attackJoystick;
        
        protected override void Install(IPlayerContext context)
        {
            var gameContext = GameContext.Instance;
            
            //gameContext.SetPlayer(context);
            
            context.AddMoveJoystick(_moveJoystick);
            context.AddAttackJoystick(_attackJoystick);
            context.AddCharacter(_character);
            //gameContext.GetPlayer().AddCharacter(_character);
            gameContext.GetPlayers().Add(1, context);
            context.AddController<CharacterAttackController>();
            context.AddController<CharacterMoveController>();
            context.AddController<CharacterInteractController>();
        }
    }
}