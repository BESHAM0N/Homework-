using UnityEngine;

namespace Component
{
    public sealed class RepulsionController : MonoBehaviour
    {
        [SerializeField] private RepulsionComponent _repulsionComponent;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _repulsionComponent.SetRepulsionType(RepulsionType.DropOff);
                _repulsionComponent.ExecuteAction();
            }
            else if(Input.GetMouseButtonDown(0))
            {
                _repulsionComponent.SetRepulsionType(RepulsionType.Push);
                _repulsionComponent.ExecuteAction();
            }
        }
    }
}