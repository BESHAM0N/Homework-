using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [RequireComponent(typeof(Collider))]
    public sealed class MeleeHitView : MonoBehaviour
    {
        [SerializeField] private EcsView _owner;
        [SerializeField] private Collider _hitbox;

        private void Reset()
        {
            _hitbox = GetComponent<Collider>();
            _hitbox.isTrigger = true;
        }

        public void EnableHitbox()  => _hitbox.enabled = true;
        public void DisableHitbox() => _hitbox.enabled = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EcsView targetView))
                return;

            var systems = EcsAdmin.Systems;
            var world   = systems.GetWorld();

            var attacker = _owner.GetPackedEntity();
            var target   = targetView.GetPackedEntity();
          
            world.GetEvent<MeleeHitRequest>().Fire(new MeleeHitRequest {
                attacker = attacker,
                target   = target
            });
        }
    }
}