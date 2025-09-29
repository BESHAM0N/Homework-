using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(
        fileName = "TeamViewConfig",
        menuName = "ECSGame/Common/New TeamViewConfig"
    )]
    public sealed class TeamViewConfig : ScriptableObject
    {
        [SerializeField] private TeamInfo[] _teams;

        public TeamInfo GetTeam(TeamType teamType)
        {
            for (int i = 0, count = _teams.Length; i < count; i++)
            {
                TeamInfo info = _teams[i];
                if (info.Type == teamType)
                    return info;
            }

            throw new KeyNotFoundException($"Team of type {teamType} is not found!");
        }

        [Serializable]
        public sealed class TeamInfo
        {
            [SerializeField] private TeamType _type;

            [SerializeField] private GameObject _prefabArcher;
            [SerializeField] private GameObject _prefabSwordman;
            [SerializeField] private GameObject _prefabArrow;
            [SerializeField] private GameObject _prefabBuilding;

            public GameObject GetPrefabArcher => _prefabArcher;
            public GameObject GetPrefabSwordman => _prefabSwordman;
            public GameObject GetPrefabArrow => _prefabArrow;
            public GameObject GetPrefabBuilding => _prefabBuilding;

            public TeamType Type
            {
                get { return _type; }
            }

            public int CameraDisplay
            {
                get { return (int)this._type - 1; }
            }
        }
    }
}