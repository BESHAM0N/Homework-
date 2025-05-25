using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.Controllers;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.Scripts.PlayerContext
{
    public class PlayerContextInstaller : SceneContextInstaller<IPlayerContext>
    {
        [SerializeField] private SceneEntity _character;
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _attackJoystick;
        
        protected override void Install(IPlayerContext context)
        {
            context.AddCharacter(_character);
            context.AddMoveJoystick(_moveJoystick);
            context.AddAttackJoystick(_attackJoystick);
            context.AddController<CharacterAttackController>();
            context.AddController<CharacterMoveController>();
        }
    }
}