using System;
using UnityEngine;

namespace Game.Presenters
{
    public interface IPlanetPopupPresenter
    {
        event Action OnStateChanged;

        string PlanetName { get; }
        string Population { get; }
        Sprite Icon { get; }
        string UpgradePrice { get; }
        string Income { get; }
        string LevelText { get; }

        bool CanUpgrade();
        void Upgrade();
    }
}