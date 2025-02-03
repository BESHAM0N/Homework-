using System;
using Game.Gameplay.Attributes;
using Modules.Entities;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly EntityWorld _entityWorld;

        [Inject]
        public EntityFactory(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        public void CreateEntity(EntityData entityData)
        {
            var entity = _entityWorld.Spawn(entityData.Name, entityData.Position, Quaternion.Euler(entityData.Rotation), entityData.Id);

            foreach (var comp in entity.GetComponents<MonoBehaviour>())
            {
                foreach (var field in comp.GetType().GetFields())
                {
                    if (Attribute.IsDefined(field, typeof(VariableAttribute)) &&
                        entityData.Components.TryGetValue(field.Name, out var value))
                    {
                        field.SetValue(comp, value);
                    }
                }
            }
        }
    }
}