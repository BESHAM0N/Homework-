using System;
using Modules.Money;
using Modules.Planets;
using UnityEngine;
using Zenject;

public class MoneyPresenter :  IDisposable, IInitializable
{
    private readonly MoneyView _moneyView;
    private readonly IMoneyStorage _moneyStorage;
    private readonly Planet _planet;
    
    public MoneyPresenter(MoneyView moneyView, Planet planet, IMoneyStorage moneyStorage)
    {
        _moneyView = moneyView;
        _planet = planet;
        _moneyStorage = moneyStorage;
    }

    public void Initialize()
    {
        _moneyView.OnClicked += CollectMoney;
    }

    public void Dispose()
    {
        _moneyView.OnClicked -= CollectMoney;
    }

    private void UpdateMoneyUI(int newAmount, int prevAmount)
    {
       
    }

    private void CollectMoney()
    {
        Debug.Log($"CollectMoney, Planet: {_planet.Name}");
        if (!_planet.IsIncomeReady) return;
        
        _planet.GatherIncome();
    }
}
