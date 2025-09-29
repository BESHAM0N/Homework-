using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public static class TeamViewUseCase
    {
        public static string GetViewKey(TeamViewConfig config, TeamType team, UnitType type)
        {
            var info = config.GetTeam(team);
            GameObject go = type switch {
                UnitType.Archer   => info.GetPrefabArcher,
                UnitType.Swordman => info.GetPrefabSwordman,
                UnitType.Arrow    => info.GetPrefabArrow,
                UnitType.Building => info.GetPrefabBuilding,
                _ => null
            };
            if (!go) return null;
            return go.name;
            
            // var info = config.GetTeam(team);
            // GameObject gameObject = type switch
            // {
            //     UnitType.Archer => info.GetPrefabArcher,
            //     UnitType.Swordman => info.GetPrefabSwordman,
            //     UnitType.Arrow => info.GetPrefabArrow,
            //     UnitType.Building => info.GetPrefabBuilding,
            //     _ => null
            // };
            // if (!gameObject) return null;
            // var view = gameObject.GetComponent<EcsView>();
            // return view != null ? view.Name : gameObject.name;
        }

        public static string ResolvePrototypeNameByViewName(TeamViewConfig config, string viewName)
        {
            foreach (TeamType teamType in System.Enum.GetValues(typeof(TeamType)))
            {
                var info = config.GetTeam(teamType);

                if (SafeName(info.GetPrefabArcher) == viewName) return "Archer";
                if (SafeName(info.GetPrefabSwordman) == viewName) return "Swordman";
                if (SafeName(info.GetPrefabArrow) == viewName) return "Arrow";
                if (SafeName(info.GetPrefabBuilding) == viewName) return "Base";
            }

            return viewName;
        }

        private static string SafeName(GameObject gameObject)
        {
            if (!gameObject) return null;
            var v = gameObject.GetComponent<EcsView>();
            return v != null ? v.Name : gameObject.name;
        }
    }
}