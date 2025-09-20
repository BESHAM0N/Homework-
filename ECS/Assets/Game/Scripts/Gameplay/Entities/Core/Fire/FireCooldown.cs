using System;

namespace ECSGame
{
    [Serializable]
    public struct FireCooldown
    {
        public float duration;
        public float current;
    }
}