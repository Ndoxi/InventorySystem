using IS.Core.Models;
using IS.Data;
using System;
using System.Collections.Generic;

namespace IS.Services
{
    public interface IInventoryService
    {
        event Action<IRuntimeItemData<ItemData>> itemAdded;
        event Action<IRuntimeItemData<ItemData>> itemRemoved;
        IReadOnlyList<IRuntimeItemData<ItemData>> items { get; }
        void Add(IRuntimeItemData<ItemData> runtimeItemData);
        void Use(IRuntimeItemData<ItemData> runtimeItemData);
        void Remove(IRuntimeItemData<ItemData> runtimeItemData);
    }
}
