using System.Collections.Generic;
using Modules.Entities;

namespace Game.Scripts.Serialization
{
    public interface IGameSerializer
    {
        string Serialize(IEnumerable<Entity> entities);
        List<EntityData> Deserialize(string json);
    }
}