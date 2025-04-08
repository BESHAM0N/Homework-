using UnityEngine;

namespace Component
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] private DropOffComponent _dropOffComponent;
        [SerializeField] private SoundComponent _soundComponent;

        private void OnEnable()
        {
            _dropOffComponent.OnDropOff += OnDrop;
        }
        
        private void OnDisable()
        {
            _dropOffComponent.OnDropOff -= OnDrop;
        }

        private void Update()
        {
            _dropOffComponent.ExecuteDropOff();
        }

        private void OnDrop()
        {
            Debug.Log("Trampoline");
            _soundComponent.PlaySound(SoundType.Trampline);
        }
    }
}