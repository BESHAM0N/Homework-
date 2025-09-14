using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public sealed class ArrowCollisionView : MonoBehaviour
    {
        [SerializeField] private EcsView _view;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EcsView target))
                return;

            var systems = EcsAdmin.Systems;
            systems.GetWorld().GetEvent<ArrowCollisionRequest>().Fire(new ArrowCollisionRequest
            {
                arrow = _view.GetPackedEntity(),
                target = target.GetPackedEntity()
            });
        }
    }
}