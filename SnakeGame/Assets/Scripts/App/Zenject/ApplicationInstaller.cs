using UnityEngine;
using Zenject;

namespace SnakeGame
{
    [CreateAssetMenu(
        fileName = "ApplicationInstaller",
        menuName = "Zenject/New ApplicationInstaller"
    )]
    public sealed class ApplicationInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            GameUIInstaller.Install(Container);
        }
    }
}