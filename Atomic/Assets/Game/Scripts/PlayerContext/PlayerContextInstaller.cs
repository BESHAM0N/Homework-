using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.Controllers;
using Modules.Common;
using SampleGame;
using UnityEngine;
using GameContextInstance = Game.Scripts.GameContext.GameContext;

namespace Game.Scripts.PlayerContext
{
    public class PlayerContextInstaller : SceneContextInstaller<IPlayerContext>
    {
        [SerializeField] private SceneEntity _character;
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _attackJoystick;
        
        protected override void Install(IPlayerContext context)
        {
            GameContextInstance gameContext = GameContextInstance.Instance;
            
            gameContext.SetPlayer(context);
            
            context.AddMoveJoystick(_moveJoystick);
            context.AddAttackJoystick(_attackJoystick);
            context.AddCharacter(_character);
            gameContext.GetPlayer().AddCharacter(_character);
            context.AddController<CharacterAttackController>();
            context.AddController<CharacterMoveController>();
            context.AddController<CharacterInteractController>();
        }
    }
}