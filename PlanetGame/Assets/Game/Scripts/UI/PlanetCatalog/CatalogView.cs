using Game.Planets;
using UnityEngine;
using Zenject;

public class CatalogView : MonoBehaviour
{
    [Inject] private PlanetView.Pool _planetPool;

    [SerializeField] private Transform _viewport;

    public PlanetView SpawnPlanet()
    {
        PlanetView planet = _planetPool.Spawn();
        planet.transform.SetParent(_viewport, false);
        return planet;
    }

    public sealed class Factory : PlaceholderFactory<CatalogView>
    {
    }
}
