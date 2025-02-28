using Modules.Planets;
using UnityEngine;
using Zenject;

public class MoneyInstaller : Installer<MoneyInstaller>
{
    [Inject] private MoneyView _moneyView;
    [Inject] private Planet _planet;

    public override void InstallBindings()
    {
        Container.Bind<MoneyView>().FromInstance(_moneyView).AsSingle();
        Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().WithArguments(_planet);
    }
}