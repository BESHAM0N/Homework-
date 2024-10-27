using UnityEngine;

public class PointService : MonoBehaviour
{
    [Header("PositionPoints")] 
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private Transform[] _attackPositions;
    
    private const int MIN_RANGE_VALUE = 0;

    public Transform GiveRandomSpawnPoint()
    {
        return GetRandomPoint(_spawnPositions);
    }
    
    public Transform GiveRandomAttackPoint()
    {
        return GetRandomPoint(_attackPositions);
    }

    private Transform GetRandomPoint(Transform[] points)
    {
        var index = Random.Range(MIN_RANGE_VALUE, points.Length);
        return points[index];
    }
}