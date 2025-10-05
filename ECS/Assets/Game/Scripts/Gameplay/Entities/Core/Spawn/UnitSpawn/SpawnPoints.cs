using System;
using UnityEngine;

namespace ECSGame
{
    [Serializable]
    public struct UnitSpawnPoints
    {
        public Transform[] points;
        public int nextIndex;
    }
}