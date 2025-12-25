using IS.Core.Factories;
using IS.Data;
using IS.Infrastracture;
using System.Collections.Generic;
using UnityEngine;

namespace IS.Core.Views
{
    public class GridView<TData> : MonoBehaviour where TData : IItemData
    {
        [SerializeField] private RectTransform _content;
        private List<ItemView<TData>> _views = new ();
        private IItemViewFactory<ItemView<TData>, TData> _factory;

        public void Init(TData[] datas)
        {
            _factory = ServiceLocator.Resolve<IItemViewFactory<ItemView<TData>, TData>>();

            foreach (var data in datas)
            {
                Add(data);
            }
        }

        public void Add(TData data)
        {
            var view = _factory.Create<ItemView<TData>>(data, _content);
            _views.Add(view);
        }

        public void Remove(ItemView<TData> view)
        {
            bool removed = _views.Remove(view);
            if (removed)
                Destroy(view.gameObject);
        }
    }
}