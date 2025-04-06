using UnityEngine;
using Component;

public class PushController : MonoBehaviour
{
    [SerializeField] private PushComponent _pushComponent;
  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pushComponent.ExecutePush();
        }
    }
}