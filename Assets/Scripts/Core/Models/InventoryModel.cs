using IS.Data;
using System;
using System.Collections.Generic;

namespace IS.Core.Models
{
    public class InventoryModel<T> where T : IItemData
    {
        public event Action<IRuntimeItemData<T>> itemAdded;
        public event Action<IRuntimeItemData<T>> itemRemoved;

        public IReadOnlyList<IRuntimeItemData<T>> items => _items;

        protected List<IRuntimeItemData<T>> _items = new ();

        public void Add(IRuntimeItemData<T> data)
        {
            _items.Add(data);
            itemAdded?.Invoke(data);
        }

        public void Remove(IRuntimeItemData<T> data)
        {
            if (_items.Remove(data))
                itemRemoved?.Invoke(data);
        }
    }
}
