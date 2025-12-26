using IS.Core.Factories;
using IS.Data;
using IS.Infrastracture;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace IS.Core.Views
{
    public class GridView<TView, TData> : MonoBehaviour 
        where TView : ItemView<TData> 
        where TData : IItemData
    {
        [SerializeField] private RectTransform _content;
        private Dictionary<Guid, TView> _views = new ();
        private IItemViewFactory<TView, TData> _factory;

        public void Init(IRuntimeItemData<TData>[] datas)
        {
            _factory = ServiceLocator.Resolve<IItemViewFactory<TView, TData>>();

            foreach (var data in datas)
            {
                Add(data);
            }
        }

        public void Add(IRuntimeItemData<TData> data)
        {
            var view = _factory.Create<TView>(data, _content);
            _views.Add(data.instanceId, view);
            RegistedView(view);
        }

        public void Remove(IRuntimeItemData<TData> data)
        {
            if (_views.TryGetValue(data.instanceId, out var view))
            {
                UnregistedView(view);
                _views.Remove(data.instanceId);
                Destroy(view.gameObject);
            }
        }

        protected virtual void RegistedView(TView view) { }
        protected virtual void UnregistedView(TView view) { }
    }
}