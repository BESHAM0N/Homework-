using Modules.Planets;
using Game.Views;

namespace Game.Presenters
{
    public class PlanetPopupShower : IPlanetShower
    {
        private PlanetPopupPresenter _planetPresenter;
        private PlanetPopup _planetPopup;

        public PlanetPopupShower(PlanetPopupPresenter planetPresenter, PlanetPopup planetPopup)
        {
            _planetPresenter = planetPresenter;
            _planetPopup = planetPopup;
        }

        public void Show(Planet planet)
        {
            _planetPresenter.ChangePlanet(planet);
            _planetPopup.Show();
        }
    }
}