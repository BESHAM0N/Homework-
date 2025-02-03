using Game.Gameplay.Attributes;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class DestinationPoint : MonoBehaviour
    {
        ///Variable
        [field: SerializeField, Variable]
        public Vector3 Value { get; set; }
    }
}