using UnityEngine;
using Component;

public sealed class DropOffController : MonoBehaviour
{
    [SerializeField] private DropOffComponent _dropOffComponent;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _dropOffComponent.ExecuteDropOff();
        }
    }
}