using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Planets
{
    public class CatalogPresenter : IInitializable, IDisposable
    {
        private readonly PlanetCatalog _catalog;
        private readonly CatalogView _view;
        private readonly PlanetIconPresenter.Factory _presenterFactory;

        private readonly Dictionary<Planet, PlanetIconPresenter> _presenters = new();

        public CatalogPresenter(
            PlanetCatalog catalog,
            CatalogView view,
            PlanetIconPresenter.Factory presenterFactory)
        {
            _catalog = catalog;
            _view = view;
            _presenterFactory = presenterFactory;
        }

        public void Initialize()
        {
            foreach (PlanetConfig config in _catalog.GetPlanets())
            {
                Planet planet = new Planet(config, null); // IMoneyAdapter can be injected later
                PlanetView planetIcon = _view.SpawnPlanet();
                PlanetIconPresenter presenter = _presenterFactory.Create(planet, planetIcon);
                
                presenter.Initialize();
                _presenters.Add(planet, presenter);
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters.Values)
            {
                presenter.Dispose();
            }
            _presenters.Clear();
        }
    }
}