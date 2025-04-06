using UnityEngine;
using Component;

public class JumpController : MonoBehaviour
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