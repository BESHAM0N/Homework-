using UnityEngine;
using Zenject;

namespace SnakeGame
{
    
    [CreateAssetMenu(fileName = "GameUIInstaller", menuName = "UI/New GameUIInstaller")]
    public class GameUIInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameUI>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UILevelController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIScoreController>().AsSingle().NonLazy();
        }
    }
}