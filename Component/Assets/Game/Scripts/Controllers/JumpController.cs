using UnityEngine;
using Component;

public sealed class JumpController : MonoBehaviour
{
    [SerializeField] private JumpComponent _jumpComponent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpComponent.ExecuteJump();
        }
    }
}