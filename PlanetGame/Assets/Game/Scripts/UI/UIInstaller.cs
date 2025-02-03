using Game.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField]
        private PlanetPopup _prefab;

        [SerializeField]
        private Transform _poolContainer;

        [SerializeField]
        private Transform _screenContainer;
        
        public override void InstallBindings()
        {
            PlanetPopupInstaller.Install(this.Container);
        }
    }
}