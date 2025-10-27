using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [RequireComponent(typeof(Collider))]
    public sealed class MeleeHitView : MonoBehaviour
    {
        private EcsView _owner;
        private bool _active;

        private void Awake()
        {
            if (_owner == null)
                _owner = GetComponentInParent<EcsView>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EcsView target))
                return;

            var systems = EcsAdmin.Systems;
            
            Debug.Log($"attacker: {_owner.GetPackedEntity().Id}, target: {target.GetPackedEntity().Id}");
          
            systems.GetWorld().GetEvent<MeleeHitRequest>().Fire(new MeleeHitRequest {
                attacker = _owner.GetPackedEntity(),
                target   = target.GetPackedEntity()
            });
        }
    }
}