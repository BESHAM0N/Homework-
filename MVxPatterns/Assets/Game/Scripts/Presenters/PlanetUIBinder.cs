using System.Collections.Generic;
using Game.Presenters;
using Game.Views;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Common
{
    public class PlanetUIBinder  : IInitializable
    {
        [Inject] private PlanetCatalog _catalog;
        [Inject] private PlanetCard[] _planetCards;
        [Inject] private List<Planet> _planets;
        [Inject] private PlanetCardPresenter.Factory _presenterFactory;

        public void Initialize()
        {
            for (int i = 0; i < _catalog.Count && i < _planetCards.Length && i < _planets.Count; i++)
            {
                Planet planet = _planets[i];
                PlanetCard card = _planetCards[i];
                PlanetCardPresenter presenter = _presenterFactory.Create(planet, card);
                presenter.Initialize();
                
                Debug.Log($"planetName: {planet.Name}");
            }
        }
    }
}