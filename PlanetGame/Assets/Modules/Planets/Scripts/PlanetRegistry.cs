using System.Collections.Generic;

namespace Modules.Planets
{
    public class PlanetRegistry
    {
        private readonly Dictionary<PlanetConfig, Planet> _planets = new();

        public void Register(PlanetConfig config, Planet planet)
        {
            if (!_planets.ContainsKey(config))
            {
                _planets[config] = planet;
            }
        }

        public Planet GetPlanet(PlanetConfig config)
        {
            return _planets.TryGetValue(config, out var planet) ? planet : null;
        }
    }
}