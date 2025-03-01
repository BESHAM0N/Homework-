using System;
using Modules.Money;
using Zenject;

public class CurrencyPresenter : IInitializable, IDisposable
{
   private CurrencyView _view;
   private IMoneyStorage _moneyStorage;

   public CurrencyPresenter(CurrencyView view, IMoneyStorage moneyStorage)
   {
      _view = view;
      _moneyStorage = moneyStorage;
   }

   public void Initialize()
   {
      _moneyStorage.OnMoneyChanged += SetMoney;
      _view.SetMoney(_moneyStorage.Money.ToString());
   }

   public void Dispose()
   {
      _moneyStorage.OnMoneyChanged -= SetMoney;
   }

   private void SetMoney(int newValue, int prevValue)
   {
      _view.SetMoney(newValue.ToString());
   }
}
