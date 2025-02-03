using System.Collections.Generic;
using Game.Gameplay.Attributes;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class ProductionOrder : MonoBehaviour
    {
        ///Variable
        [SerializeField, Variable]
        private List<EntityConfig> _queue;
        
        public IReadOnlyList<EntityConfig> Queue
        {
            get { return _queue; }
            set { _queue = new List<EntityConfig>(value); }
        }
    }
}