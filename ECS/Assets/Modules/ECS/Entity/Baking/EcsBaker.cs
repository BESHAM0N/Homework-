using UnityEngine;

namespace Leopotam.EcsLite
{
    public class EcsBaker: MonoBehaviour
    {
        [SerializeField] private EcsPrototypeCatalog _prototypes;

        public void BakeScene(EcsWorld world, bool includeInactive = false)
        {
           var views = FindObjectsOfType<EcsView>(includeInactive);
         
            for (int i = 0, count = views.Length; i < count; i++)
            {
                var view = views[i];
                BakeEntity(world, view);
            }
        }

        public void BakeEntity(in EcsWorld world, in EcsView view)
        {
            var prototypeName = view.Name;
            var prefab = _prototypes.GetPrototype(prototypeName);

            var entity = prefab.Create(world);
            var converters = view.GetComponentsInChildren<IEcsEntityInstaller>();
            
            for (int i = 0, count = converters.Length; i < count; i++)
            {
                var converter = converters[i];
                converter.Install(world, entity);
            }

            Destroy(view.gameObject);
        }
    }
}