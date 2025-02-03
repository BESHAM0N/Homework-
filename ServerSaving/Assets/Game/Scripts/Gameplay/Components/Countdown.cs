using Game.Gameplay.Attributes;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Countdown : MonoBehaviour
    {
        ///Variable
        [field: SerializeField, Variable]
        public float Current { get; set; }

        ///Const
        [field: SerializeField, Const]
        public float Duration { get; private set; }
    }
}