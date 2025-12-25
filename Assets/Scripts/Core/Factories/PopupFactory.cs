using IS.Core.Views;
using IS.Data.Configs;
using IS.Infrastracture;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IS.Core.Factories
{
    public class PopupFactory : UIFactory<Popup>
    {
        protected override Canvas _canvas { get; }

        private readonly Dictionary<Type, Popup> _prefabs;

        public PopupFactory(Canvas canvas)
        {
            _canvas = canvas;
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<PopupFactoryConfig>();
            _prefabs = new Dictionary<Type, Popup>(config.prefabs.Length);

            foreach (var prefab in config.prefabs)
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
