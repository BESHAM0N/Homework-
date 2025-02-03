using Game.Gameplay.Attributes;
using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class ResourceBag : MonoBehaviour
    {
        ///Variable
        [field: SerializeField, Variable]
        public ResourceType Type { get; set; }
        
        ///Variable
        [field: SerializeField, Variable]
        public int Current { get; set; }
        
        ///Const
        [field: SerializeField, Variable]
        public int Capacity { get; set; }
    }
}