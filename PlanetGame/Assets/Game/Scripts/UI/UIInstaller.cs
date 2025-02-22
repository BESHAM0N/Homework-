using Game.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private PlanetView _prefabPlanet;
        [SerializeField] private PlanetPopup _prefab;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private Transform _screenContainer;

        public override void InstallBindings()
        {
            PlanetPopupInstaller.Install(Container);
            PlanetIconInstaller.Install(Container, _prefabPlanet, _poolContainer);
        }
    }
}