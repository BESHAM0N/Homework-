using Game.Gameplay.Attributes;
using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Team : MonoBehaviour
    {
        ///Variable
        [field: SerializeField, Variable]
        public TeamType Type { get; set; }
    }
}