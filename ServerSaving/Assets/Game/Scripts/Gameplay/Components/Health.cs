using Game.Gameplay.Attributes;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Health : MonoBehaviour
    {
        ///Variable
        [field: SerializeField, Variable]
        public int Current { get; set; } = 50;

        ///Const
        [field: SerializeField, Const]
        public int Max { get; private set; } = 100;
    }
}