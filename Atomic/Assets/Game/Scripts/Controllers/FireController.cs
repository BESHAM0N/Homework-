using Atomic.Entities;
using Game.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class FireController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;

        private void Update()
        {
           if(Input.GetKeyDown(KeyCode.Space))
               _character.GetFireAction().Invoke();
        }
        
    }
}