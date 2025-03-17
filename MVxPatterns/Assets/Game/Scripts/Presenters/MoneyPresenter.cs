using System;
using Game.Views;
using Modules.Money;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public class MoneyPresenter : IInitializable, IDisposable
    {
        public Vector3 MoneyTransform => _view.transform.position;
        private MoneyView _view;
        private IMoneyStorage _moneyStorage;

        public MoneyPresenter(MoneyView view, IMoneyStorage moneyStorage)
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
}