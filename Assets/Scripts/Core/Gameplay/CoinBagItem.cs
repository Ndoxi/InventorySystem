using IS.Core.Models;
using IS.Infrastracture;
using UnityEngine;

namespace IS.Core.Gameplay.Items
{
    public class CoinBagItem : IItem
    {
        private readonly int _amount;

        public CoinBagItem(int amount)
        {
            _amount = amount;
        }

        public void Use()
        {
            var currency = ServiceLocator.Resolve<ICurrencyModel>();
            currency.Add(_amount);
        }
    }
}