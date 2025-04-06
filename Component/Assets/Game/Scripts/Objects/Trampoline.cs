using UnityEngine;

namespace Component
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] private DropOffComponent _dropOffComponent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _dropOffComponent.ExecuteDropOff();
        }
    }
}