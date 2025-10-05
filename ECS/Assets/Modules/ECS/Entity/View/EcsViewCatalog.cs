using System;
using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.EcsLite
{
    [CreateAssetMenu(
        fileName = "EcsViewCatalog",
        menuName = "ECSGame/View/new EcsViewCatalog"
    )]
    public class EcsViewCatalog : ScriptableObject
    {
        [SerializeField] private List<EcsView> _prefabs;

       public int Count => _prefabs.Count;
       
        public KeyValuePair<string, EcsView> GetPrefab(int index)
        {
            EcsView view = _prefabs[index];
            Debug.Log($"GetPrefab. index: {index}, view: {view.gameObject.name}");
            return new KeyValuePair<string, EcsView>(GetName(view), view);
        }

        public EcsView GetPrefab(string name)
        {
            for (int i = 0, count = _prefabs.Count; i < count; i++)
            {
                EcsView prefab = _prefabs[i];
                string prefabName = this.GetName(prefab);
                if (prefabName == name)
                    return prefab;
            }

            throw new Exception($"Prefab with name {name} is not found!");
        }

        protected virtual string GetName(EcsView prefab)
        {
            Debug.Log($"GetName: {prefab.Name}");
            return prefab.Name;
        }
    }
}