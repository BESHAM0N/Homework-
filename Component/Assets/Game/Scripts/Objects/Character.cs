using Component;
using UnityEngine;

//Facade
public sealed class Character : MonoBehaviour, IPushComponent, ITossComponent
{
    [SerializeField] private LifeComponent _lifeComponent;
    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private RotateComponent _rotateComponent;
    [SerializeField] private JumpComponent _jumpComponent;
    [SerializeField] private DeathComponent _deathComponent;
    [SerializeField] private RepulsionComponent _pushComponent;
    [SerializeField] private RepulsionComponent _tossComponent;
    
    public void Push()
    {
        _pushComponent.ExecuteAction(Vector2.zero);
    }

    public void Toss()
    {
        _tossComponent.ExecuteAction(Vector2.up);
    }

    private void Awake()
    {
        _moveComponent.AddCondition(_lifeComponent.IsAlive);
        _jumpComponent.AddCondition(_lifeComponent.IsAlive);
        _pushComponent.AddCondition(_lifeComponent.IsAlive);
        _tossComponent.AddCondition(_lifeComponent.IsAlive);
        _tossComponent.AddCondition(() => _jumpComponent.OnGround);
        _pushComponent.AddCondition(() => _jumpComponent.OnGround);
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