using Component;
using UnityEngine;

//Facade
public sealed class Character : MonoBehaviour
{
    [SerializeField] private LifeComponent _lifeComponent;
    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private RotateComponent _rotateComponent;
    [SerializeField] private JumpComponent _jumpComponent;
    [SerializeField] private DeathComponent _deathComponent;
    [SerializeField] private RepulsionComponent _repulsionComponent;
    
    private void Awake()
    {
        _moveComponent.AddCondition(_lifeComponent.IsAlive);
        _jumpComponent.AddCondition(_lifeComponent.IsAlive);
        _repulsionComponent.AddCondition(_lifeComponent.IsAlive);
        _repulsionComponent.AddCondition(() => _jumpComponent.OnGround);
    }

    private void OnEnable()
    {
        _lifeComponent.OnEmpty += OnHealthEmpty;
        _moveComponent.OnRotate += _rotateComponent.SetDirection;
    }

    private void OnDisable()
    {
        _lifeComponent.OnEmpty -= OnHealthEmpty;
        _moveComponent.OnRotate -= _rotateComponent.SetDirection;
    }

    private void OnHealthEmpty()
    {
        _deathComponent.Death();
    }
}
