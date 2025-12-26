using System;

namespace IS.Core.Models
{
    public interface ICurrencyModel
    {
        event Action<int> updated;
        int amount { get; }
        void Add(int amount);
        void Remove(int amount);
    }
}
