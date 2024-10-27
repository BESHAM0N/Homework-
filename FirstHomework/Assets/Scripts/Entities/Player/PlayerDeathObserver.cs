using ShootEmUp;
using UnityEngine;

public sealed class PlayerDeathObserver : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnEnable()
    {
        _player.OnHealthEmpty += GameOver;
    }
    
    private  void GameOver()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _player.OnHealthEmpty -= GameOver;
    }
}
