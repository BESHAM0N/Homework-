using Game.Views;
using Modules.Money;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public class MoneyPresenter : IInitializable
    {
        public Vector3 MoneyTransform => _view.MoneyIconPosition;
        private MoneyView _view;
        private IMoneyStorage _moneyStorage;

        public MoneyPresenter(MoneyView view, IMoneyStorage moneyStorage)
        {
            _view = view;
            _moneyStorage = moneyStorage;
        }

        public void Initialize()
        {
            _view.SetMoney(_moneyStorage.Money.ToString());
        }
        
        public void UpdateMoney()
        {
            _view.UpdateMoney(_moneyStorage.Money.ToString());
        }
    }
}