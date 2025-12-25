using IS.Core.Views;
using IS.Data.Configs;
using IS.Infrastracture;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace IS.Core.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly Canvas _canvas;
        private readonly Dictionary<Type, View> _prefabs;
        
        public ViewFactory(Canvas canvas) 
        {
            _canvas = canvas;
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<ViewFactoryConfig>();
            _prefabs = new Dictionary<Type, View>(config.prefabs.Count);

            foreach (var prefab in config.prefabs)
            {
                _prefabs.Add(prefab.GetType(), prefab);
            }
        }

        public T Create<T>() where T : class, IView
        {
            var prefab = _prefabs.GetValueOrDefault(typeof(T));
            if (prefab == null)
                throw new Exception($"Prefab of type {typeof(T)} is not registered in ViewFactory");
            return UnityEngine.Object.Instantiate(prefab, _canvas.transform) as T;
        }
    }
}
