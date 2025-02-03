using Game.Gameplay.Attributes;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class TargetObject : MonoBehaviour
    {
        ///Variable
        [field: SerializeField, Variable]
        public Entity Value { get; set; }
    }
}