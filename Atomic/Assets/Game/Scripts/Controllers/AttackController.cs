using Atomic.Entities;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private Joystick _attackJoystick;
        [SerializeField] private SceneEntity _sceneEntity;

        private void Update()
        {
            var input = _attackJoystick.Direction;
            var direction = new Vector3(input.x, 0f, input.y);
            _sceneEntity.GetRotateDirection().Value = direction;
        }
    }
}