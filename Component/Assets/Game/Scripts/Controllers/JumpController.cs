using UnityEngine;
using Component;

public sealed class JumpController : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    private JumpComponent _jumpComponent;

    private void Start()
    {
        _jumpComponent = _character.GetComponent<JumpComponent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpComponent.ExecuteJump();
        }
    }
}