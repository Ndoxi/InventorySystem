using IS.Core.Views;
using IS.Data;
using UnityEngine;

namespace IS.Core.Factories
{
    public abstract class BaseItemViewFactory<TItem, TData> : IItemViewFactory<TItem, TData>
        where TItem : ItemView<TData>
        where TData : IItemData
    {
        protected abstract TItem _prefab { get; }

        public T Create<T>(TData data, Transform parent) where T : TItem
        {
            var view = Object.Instantiate(_prefab, parent);
            view.Init(data);
            return view as T;
        }
    }
}
