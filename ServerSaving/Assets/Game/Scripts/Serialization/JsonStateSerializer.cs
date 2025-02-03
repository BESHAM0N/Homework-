using System;
using System.Collections.Generic;
using System.Reflection;
using Game.Gameplay.Attributes;
using Modules.Entities;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.Serialization
{
    public class JsonGameSerializer : IGameSerializer
    {
        public string Serialize(IEnumerable<Entity> entities)
        {
            List<EntityData> entityList = new();

            foreach (var entity in entities)
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

        public List<EntityData> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<EntityData>>(json);
        }
    }
}