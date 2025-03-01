using Zenject;

namespace Game.Scripts.UI.Currency
{
    public class CurrencyInstaller : Installer<CurrencyView, CurrencyInstaller>
    {
        [Inject] private CurrencyView _currencyView;
        
        public override void InstallBindings()
        {
            Container.Bind<CurrencyView>().FromInstance(_currencyView).AsSingle();
            Container.BindInterfacesAndSelfTo<CurrencyPresenter>().AsSingle().NonLazy();
        }
    }
}