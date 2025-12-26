using IS.Core.Views;
using IS.Data;
using UnityEngine;

namespace IS.Core.Factories
{
    public interface IItemViewFactory<TItem, TData> 
        where TItem : ItemView<TData> 
        where TData : IItemData
    {
        T Create<T>(TData data, Transform parent) where T : TItem;
        T Create<T>(IRuntimeItemData<TData> runtimeData, Transform parent) where T : TItem;
    }
}
