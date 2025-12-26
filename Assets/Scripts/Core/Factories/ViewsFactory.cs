using IS.Core.Views;
using IS.Data.Configs;
using IS.Infrastracture;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace IS.Core.Factories
{
    public class ViewFactory : UIFactory<View>
    {
        protected override Canvas _canvas { get; }

        private readonly Dictionary<Type, View> _prefabs;

        public ViewFactory(Canvas canvas) 
        {
            _canvas = canvas;
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<ViewFactoryConfig>();
            _prefabs = new Dictionary<Type, View>(config.items.Length);

            foreach (var prefab in config.items)
            {
                _prefabs.Add(prefab.GetType(), prefab);
            }
        }

        protected override T GetPrefabOrDefault<T>()
        {
            return _prefabs.GetValueOrDefault(typeof(T)) as T;
        }
    }
}
