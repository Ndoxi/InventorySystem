using System;
using System.Collections.Generic;
using UnityEngine;

namespace IS.Infrastracture
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly Dictionary<Type, object> _configs;

        public ConfigProvider(ScriptableObject[] configs)
        {
            _configs = new Dictionary<Type, object>(configs.Length);
            foreach (var config in configs)
            {
                _configs.Add(config.GetType(), config);
            }
        }

        public T Get<T>() where T : ScriptableObject
        {
            var config = _configs.GetValueOrDefault(typeof(T));
            return config as T;
        }
    }
}
