using IS.Core.Factories;
using IS.Infrastracture;
using System;
using System.Collections.Generic;

namespace IS.Core.Views
{
    public class ViewRouter : IViewRouter
    {
        private readonly Dictionary<Type, View> _viewPool = new();
        private readonly IFactory<View> _factory;

        public ViewRouter() 
        {
            _factory = ServiceLocator.Resolve<IFactory<View>>();
        }

        public T Open<T>() where T : View
        {
            var view = GetOrCreate<T>();
            view.Show();
            return view;
        }

        public void Close<T>() where T : View
        {
            var view = Get<T>();
            view?.Hide();
        }

        private T GetOrCreate<T>() where T : View
        {
            if (_viewPool.TryGetValue(typeof(T), out View value))
                return value as T;

            var view = _factory.Create<T>();
            _viewPool.Add(typeof(T), view);
            return view;
        }

        private T Get<T>() where T : class, IPanel
        {
            if (_viewPool.TryGetValue(typeof(T), out View value))
                return value as T;
            return null;
        }
    }
}