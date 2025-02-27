using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    //Don't modify
    [CreateAssetMenu(
        fileName = "GameplayInstaller",
        menuName = "Zenject/New GameplayInstaller"
    )]
    public sealed class GameplayInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private int _initialMoney = 300;

        [SerializeField]
        private PlanetCatalog _catalog;

        public override void InstallBindings()
        {
            Container.Bind<PlanetCatalog>().FromInstance(_catalog).AsSingle(); //new
            MoneyInstaller.Install(this.Container, _initialMoney);
            PlanetInstaller.Install(this.Container, _catalog);
        }
    }
}