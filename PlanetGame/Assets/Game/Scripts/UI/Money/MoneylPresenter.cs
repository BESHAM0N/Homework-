using System;
using Modules.Money;
using Modules.Planets;
using Zenject;

public class MoneyPresenter :  IDisposable, IInitializable
{
    private readonly MoneyView _moneyView;
    private readonly IMoneyStorage _moneyStorage;
    private readonly Planet _planet;
    
    public MoneyPresenter(MoneyView moneyView, IMoneyStorage moneyAdapter, Planet planet)
    {
        _moneyView = moneyView;
        _moneyStorage = moneyAdapter;
        _planet = planet;
    }

    public void Initialize()
    {
        _moneyStorage.OnMoneyChanged += UpdateMoneyUI;
        _moneyView.OnClicked += CollectMoney;
        UpdateMoneyUI(_moneyStorage.Money, _moneyStorage.Money);
    }

    public void Dispose()
    {
        _moneyStorage.OnMoneyChanged -= UpdateMoneyUI;
        _moneyView.OnClicked -= CollectMoney;
    }

    private void UpdateMoneyUI(int newAmount, int prevAmount)
    {
        _moneyView.SetAllMoneyText(newAmount.ToString());
    }

    private void CollectMoney()
    {
        if (!_planet.IsIncomeReady) return;

        int amount = _planet.MinuteIncome;
        _moneyStorage.Earn(amount);
        _planet.GatherIncome();
    }
}
