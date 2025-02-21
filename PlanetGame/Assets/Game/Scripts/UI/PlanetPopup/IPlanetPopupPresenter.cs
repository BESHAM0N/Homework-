using System;
using UnityEngine;

namespace Game.Planets
{
    public interface IPlanetPopupPresenter
    {
        event Action OnStateChanged;

        string PlanetName { get; }
        string Population { get; }
        Sprite Icon { get; }
        string CurrentLevel { get; }
        string MaxLevel { get; }
        string UpgradePrice { get; }
        string Income { get; }
        bool IsUnlock { get; }
        bool IsNewUpgrade { get; }

        bool CanUpgrade();
        void Upgrade();
    }
}