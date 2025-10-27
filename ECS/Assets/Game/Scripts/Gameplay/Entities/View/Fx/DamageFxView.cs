using System;
using UnityEngine;

namespace ECSGame
{
    [Serializable]
    public struct DamageFxView
    {
        public ParticleSystem particle; 
        public ParticleSystem fireEffect; 
    }
}