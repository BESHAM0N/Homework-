using Atomic.Contexts;
using Atomic.Entities;
using Game.Controllers;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.Context
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [Header("Character Setup")] [SerializeField]
        private SceneEntity _character;

        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _attackJoystick;

        [Header("Systems")] [SerializeField] private BulletSystemInstaller _bulletSystem;

        protected override void Install(IGameContext context)
        {
            _bulletSystem.Install(context);

            context.AddCharacter(_character);
            context.AddMoveJoystick(_moveJoystick);
            context.AddAttackJoystick(_attackJoystick);

            context.AddController<CharacterMoveController>();
            context.AddController<CharacterAttackController>();
            context.AddController<CharacterInteractController>();
        }
    }
}

