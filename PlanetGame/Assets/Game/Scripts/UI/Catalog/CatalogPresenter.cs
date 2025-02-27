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
        private readonly IMoneyAdapter _moneyAdapter;
        private readonly PlanetCardPresenter.Factory _presenterFactory;

        private readonly Dictionary<Planet, PlanetCardPresenter> _presenters = new();

        public CatalogPresenter(
            PlanetCatalog catalog,
            CatalogView view,
            PlanetCardPresenter.Factory presenterFactory, IMoneyAdapter moneyAdapter)
        {
            _catalog = catalog;
            _view = view;
            _presenterFactory = presenterFactory;
            _moneyAdapter = moneyAdapter;
        }

        public void Initialize()
        {
            foreach (PlanetConfig config in _catalog.GetPlanets())
            {
                Planet planet = new Planet(config, _moneyAdapter);
                PlanetCard planetCard = _view.SpawnPlanet();
                PlanetCardPresenter presenter = _presenterFactory.Create(planet, planetCard);
                
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