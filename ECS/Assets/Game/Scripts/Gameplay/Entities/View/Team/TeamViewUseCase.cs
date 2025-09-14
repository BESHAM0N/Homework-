using UnityEngine;

namespace ECSGame
{
    public static class TeamViewUseCase
    {
        public static void SetTeam(in Renderer[] renderers, in TeamType teamType, in TeamViewConfig viewConfig)
        {
            TeamViewConfig.TeamInfo team = viewConfig.GetTeam(teamType);
        }
    }
}