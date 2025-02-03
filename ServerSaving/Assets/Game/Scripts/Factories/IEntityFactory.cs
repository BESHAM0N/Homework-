using Modules.Entities;

namespace Game.Scripts.Factories
{
    public interface IEntityFactory
    {
        void CreateEntity(EntityData entityData);
    }
}


