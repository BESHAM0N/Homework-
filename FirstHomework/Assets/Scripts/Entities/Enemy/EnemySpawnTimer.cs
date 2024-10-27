using System.Collections;
using ShootEmUp;
using UnityEngine;

public class EnemySpawnTimer : MonoBehaviour
{
    [SerializeField] private int _maxActiveEnemiesCount = 5;
    [SerializeField] private int _minValue = 1;
    [SerializeField] private int _maxValue = 2;
    [SerializeField] private EnemyManager _enemyManager;
    
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minValue, _maxValue));

            if (_enemyManager.ActiveEnemiesCount < _maxActiveEnemiesCount)
            {
                _enemyManager.EnemySpawn();
            }
        }
    }
}
