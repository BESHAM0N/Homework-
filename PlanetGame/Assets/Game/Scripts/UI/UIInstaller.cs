using Game.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private PlanetCard _prefabPlanet;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private CatalogView _catalogViewPrefab;
        [SerializeField] private Transform _screenContainer;

        public override void InstallBindings()
        {
            PlanetPopupInstaller.Install(Container);
            CatalogViewInstaller.Install(Container, _catalogViewPrefab, _screenContainer);
            PlanetCardInstaller.Install(Container, _prefabPlanet, _poolContainer);
        }
    }
}