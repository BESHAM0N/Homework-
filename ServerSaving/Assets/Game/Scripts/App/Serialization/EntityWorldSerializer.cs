using System;
using System.Collections.Generic;
using System.Reflection;
using Game.Gameplay.Attributes;
using Modules.Entities;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.Serialization
{
    public class EntityWorldSerializer
    {
        private readonly EntityWorld _entityWorld;

        public EntityWorldSerializer(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        public string Serialize()
        {
            List<EntityData> entityList = new();
            var allEntity = _entityWorld.GetAll();

            foreach (var entity in allEntity)
            {
                EntityData data = new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Position = entity.transform.position,
                    Rotation = entity.transform.rotation.eulerAngles
                };

                foreach (var component in entity.GetComponents<MonoBehaviour>())
                {
                    foreach (var field in component.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (Attribute.IsDefined(field, typeof(VariableAttribute)) &&
                            field.GetValue(component) is float value)
                        {
                            data.Components[field.Name] = value;
                        }
                    }
                }

                entityList.Add(data);
            }

            return JsonConvert.SerializeObject(entityList);
        }

        public void Deserialize(string json)
        {
            var entities = JsonConvert.DeserializeObject<List<EntityData>>(json);

            _entityWorld.DestroyAll();

            foreach (var entityData in entities)
            {
                var entity = _entityWorld.Spawn(entityData.Name, entityData.Position,
                    Quaternion.Euler(entityData.Rotation), entityData.Id);

                foreach (var component in entity.GetComponents<MonoBehaviour>())
                {
                    foreach (var field in component.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (Attribute.IsDefined(field, typeof(VariableAttribute)) &&
                            entityData.Components.TryGetValue(field.Name, out var value))
                        {
                            field.SetValue(component, value);
                        }
                    }
                }
            }
        }
    }
}