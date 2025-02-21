using Modules.Planets;

namespace Game.Planets
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