using Game.Planets;
using UnityEngine;
using Zenject;

public class CatalogView : MonoBehaviour
{
    [Inject] private PlanetCard.Pool _planetPool;

    [SerializeField] private Transform _viewport;

    public PlanetCard SpawnPlanet()
    {
        PlanetCard planet = _planetPool.Spawn();
        planet.transform.SetParent(_viewport);
        return planet;
    }
    
    public void DespawnPlanet(PlanetCard planet)
    {
        if (planet != null)
            _planetPool.Despawn(planet);
    }

    public sealed class Factory : PlaceholderFactory<CatalogView>
    {
    }
}
