using Game.Planets;
using UnityEngine;
using Zenject;

public class CatalogView : MonoBehaviour
{
    [Inject] private PlanetCard.Pool _planetPool;

    [SerializeField] private Transform _viewport;
    [SerializeField] private Transform[] _spawnPoints;
    private int _spawnIndex; 

    public PlanetCard SpawnPlanet()
    {
        PlanetCard planet = _planetPool.Spawn();
        planet.transform.SetParent(_viewport);

        if (_spawnIndex < _spawnPoints.Length)
        {
            planet.transform.position = _spawnPoints[_spawnIndex].position;
            _spawnIndex++; 
        }
        
        return planet;
    }

    public sealed class Factory : PlaceholderFactory<CatalogView>
    {
    }
}
