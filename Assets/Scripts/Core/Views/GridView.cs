using IS.Core.Factories;
using IS.Data;
using IS.Infrastracture;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace IS.Core.Views
{
    public class GridView<TData> : MonoBehaviour where TData : IItemData
    {
        [SerializeField] private RectTransform _content;
        private Dictionary<Guid, ItemView<TData>> _views = new ();
        private IItemViewFactory<ItemView<TData>, TData> _factory;

        public void Init(IRuntimeItemData<TData>[] datas)
        {
            _factory = ServiceLocator.Resolve<IItemViewFactory<ItemView<TData>, TData>>();

            foreach (var data in datas)
            {
                Add(data);
            }
        }

        public void Add(IRuntimeItemData<TData> data)
        {
            var view = _factory.Create<ItemView<TData>>(data, _content);
            _views.Add(data.instanceId, view);
        }

        public void Remove(IRuntimeItemData<TData> data)
        {
            if (_views.TryGetValue(data.instanceId, out var view))
            {
                Destroy(view.gameObject);
                _views.Remove(data.instanceId);
            }
        }
    }
}