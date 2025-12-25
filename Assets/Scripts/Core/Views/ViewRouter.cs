using IS.Core.Factories;
using IS.Infrastracture;
using System;
using System.Collections.Generic;

namespace IS.Core.Views
{
    public class ViewRouter : IViewRouter
    {
        private readonly Dictionary<Type, IView> _viewPool = new();
        private readonly IViewFactory _factory;

        public ViewRouter() 
        {
            _factory = ServiceLocator.Resolve<IViewFactory>();
        }

        public T Open<T>() where T : class, IView
        {
            var view = GetOrCreate<T>();
            view.Show();
            return view;
        }

        public void Close<T>() where T : class, IView
        {
            var view = Get<T>();
            view?.Hide();
        }

        private T GetOrCreate<T>() where T : class, IView
        {
            if (_viewPool.TryGetValue(typeof(T), out IView value))
                return value as T;

            var view = _factory.Create<T>();
            _viewPool.Add(typeof(T), view);
            return view;
        }

        private T Get<T>() where T : class, IView
        {
            if (_viewPool.TryGetValue(typeof(T), out IView value))
                return value as T;
            return null;
        }
    }
}