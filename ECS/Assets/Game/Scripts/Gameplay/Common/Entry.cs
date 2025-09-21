using System;
using Leopotam.EcsLite;

namespace ECSGame
{
    [Serializable]
    public struct Entry
    {
        public TeamType team;
        public UnitType type;
        public EcsPrototype prototype;
        public string viewKey;
    }
}