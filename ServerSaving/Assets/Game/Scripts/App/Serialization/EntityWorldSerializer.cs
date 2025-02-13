using System;
using System.Collections.Generic;
using System.Reflection;
using Game.Gameplay.Attributes;
using Modules.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleGame.Gameplay;
using UnityEngine;

namespace Game.Scripts.Serialization
{
    public class EntityWorldSerializer
    {
        private readonly EntityWorld _entityWorld;
        private const string TARGET = "TargetObject";
        private const string PRODUCTION_ORDER = "ProductionOrder";

        public EntityWorldSerializer(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        public string Serialize()
        {
            var entityList = new List<EntityData>();

            foreach (var entity in _entityWorld.GetAll())
            {
                var data = new EntityData
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Position = entity.transform.position,
                    Rotation = entity.transform.rotation.eulerAngles
                };

                SerializeComponents(entity, data);
                entityList.Add(data);
            }

            return JsonConvert.SerializeObject(entityList);
        }

        private void SerializeComponents(Entity entity, EntityData data)
        {
            foreach (var component in entity.GetComponents<MonoBehaviour>())
            {
                SerializeVariables(component, data);
                SerializeTargetObject(component, data);
                SerializeProductionOrder(component, data);
            }
        }

        private void SerializeVariables(MonoBehaviour component, EntityData data)
        {
            foreach (var field in component.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (Attribute.IsDefined(field, typeof(VariableAttribute)) && field.GetValue(component) is float value)
                {
                    data.Components[field.Name] = value;
                }
            }
        }

        private void SerializeTargetObject(MonoBehaviour component, EntityData data)
        {
            if (component is TargetObject targetObject && targetObject.Value != null)
            {
                data.Components[TARGET] = new TargetObjectData { EntityId = targetObject.Value.Id };
            }
        }

        private void SerializeProductionOrder(MonoBehaviour component, EntityData data)
        {
            if (component is ProductionOrder productionOrder)
            {
                var queueData = new ProductionOrderData
                {
                    Queue = new List<string>()
                };

                foreach (var config in productionOrder.Queue)
                {
                    queueData.Queue.Add(config.Name);
                }

                data.Components[PRODUCTION_ORDER] = queueData;
            }
        }

        public void Deserialize(string json)
        {
            var entities = JsonConvert.DeserializeObject<List<EntityData>>(json);

            _entityWorld.DestroyAll();

            Dictionary<int, List<TargetObject>> pendingTargets = new();

            foreach (var entityData in entities)
            {
                var entity = _entityWorld.Spawn(entityData.Name, entityData.Position,
                    Quaternion.Euler(entityData.Rotation), entityData.Id);

                foreach (var component in entity.GetComponents<MonoBehaviour>())
                {
                    DeserializeVariables(component, entityData);
                    CollectPendingTargets(component, entityData, pendingTargets);
                    DeserializeProductionOrder(component, entityData);
                }
            }

            AssignPendingTargets(pendingTargets);
        }

        private void CollectPendingTargets(MonoBehaviour component, EntityData entityData,
            Dictionary<int, List<TargetObject>> pendingTargets)
        {
            if (component is TargetObject targetObject &&
                entityData.Components.TryGetValue(TARGET, out var targetData))
            {
                if (targetData is JObject jObject && jObject.ToObject<TargetObjectData>() is { } parsedTargetData)
                {
                    if (!pendingTargets.TryGetValue(parsedTargetData.EntityId, out var targetList))
                    {
                        targetList = new List<TargetObject>();
                        pendingTargets[parsedTargetData.EntityId] = targetList;
                    }

                    targetList.Add(targetObject);
                }
            }
        }

        private void DeserializeVariables(MonoBehaviour component, EntityData entityData)
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

        private void DeserializeProductionOrder(MonoBehaviour component, EntityData entityData)
        {
            if (component is ProductionOrder productionOrder &&
                entityData.Components.TryGetValue(PRODUCTION_ORDER, out var productionData))
            {
                if (productionData is JObject jObject && jObject.ToObject<ProductionOrderData>() is { } parsedData)
                {
                    var queue = new List<EntityConfig>();
                    foreach (var entityName in parsedData.Queue)
                    {
                        if (_entityWorld.GetEntityConfigByName(entityName) is EntityConfig config)
                        {
                            queue.Add(config);
                        }
                    }

                    productionOrder.Queue = queue;
                }
            }
        }

        private void AssignPendingTargets(Dictionary<int, List<TargetObject>> pendingTargets)
        {
            foreach (var (entityId, targetObjects) in pendingTargets)
            {
                if (_entityWorld.TryGet(entityId, out var targetEntity))
                {
                    foreach (var targetObject in targetObjects)
                    {
                        targetObject.Value = targetEntity;
                    }
                }
            }
        }
    }
}