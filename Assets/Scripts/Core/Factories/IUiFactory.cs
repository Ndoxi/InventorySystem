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
    }

    public class ItemFactory : IItemViewFactory<ItemView<ItemData>, ItemData>
    {
        public T Create<T>(ItemData data, Transform parent) where T : ItemView<ItemData>
        {
            throw new System.NotImplementedException();
        }
    }

    public class ShopItemFactory : IItemViewFactory<ItemView<ShopItemData>, ShopItemData>
    {
        public T Create<T>(ShopItemData data, Transform parent) where T : ItemView<ShopItemData>
        {
            throw new System.NotImplementedException();
        }
    }
}
