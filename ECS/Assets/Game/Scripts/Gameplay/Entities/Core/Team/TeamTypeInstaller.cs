using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public class TeamTypeInstaller: EcsComponentInstaller<TeamType>
    {
        [SerializeField]
        private TeamType _teamType;
        
        protected override TeamType GetValue()
        {
            return _teamType;
        }
    }
}