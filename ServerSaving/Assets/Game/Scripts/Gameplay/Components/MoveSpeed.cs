using Game.Gameplay.Attributes;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class MoveSpeed : MonoBehaviour
    {
        ///Const
        [field: SerializeField, Const]
        public float Current { get; private set; }
    }
}