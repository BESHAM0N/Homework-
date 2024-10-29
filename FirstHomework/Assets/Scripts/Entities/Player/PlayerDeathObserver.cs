using ShootEmUp;
using UnityEngine;

public sealed class PlayerDeathObserver : MonoBehaviour
{
    [SerializeField] private Ship _playerShip;
    private void OnEnable()
    {
        _playerShip.OnHealthEmpty += GameOver;
    }
    
    private  void GameOver()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _playerShip.OnHealthEmpty -= GameOver;
    }
}
