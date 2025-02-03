using Zenject;

namespace Game.Scripts.Serialization
{
    public sealed class SerializerInstaller : Installer<SerializerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonGameSerializer>().AsSingle().NonLazy();
        }
    }
}