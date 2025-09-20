using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public sealed class ProjectileCollisionView : MonoBehaviour
    {
        [SerializeField] private EcsView _view;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EcsView target))
                return;

            var systems = EcsAdmin.Systems;
            systems.GetWorld().GetEvent<ProjectileCollisionRequest>().Fire(new ProjectileCollisionRequest
            {
                projectile = _view.GetPackedEntity(),
                target = target.GetPackedEntity()
            });
        }
    }
}