using System;

namespace IS.Core.Models
{
    public class CurrencyModel : ICurrencyModel
    {
        public event Action<int> updated;
        public int amount => _amount;

        private int _amount;

        public void Add(int amount)
        {
            _amount += amount;
            updated?.Invoke(_amount);
        }

        public void Remove(int amount)
        {
            _amount -= amount;
            updated?.Invoke(_amount);
        }
    }
}
