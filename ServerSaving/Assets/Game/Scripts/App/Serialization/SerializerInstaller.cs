using Zenject;

namespace Game.Scripts.Serialization
{
    public sealed class SerializerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EntityWorldSerializer>().AsSingle().NonLazy();
        }
    }
}