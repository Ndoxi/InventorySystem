using System;
using UnityEngine;

namespace IS.Core.Factories
{
    public abstract class UIFactory<TItem> : IFactory<TItem> where TItem : MonoBehaviour
    {
        protected abstract Canvas _canvas { get; }

        public T Create<T>() where T : class, TItem
        {
            var prefab = GetPrefabOrDefault<T>();
            if (prefab == null)
                throw new Exception($"Prefab of type {typeof(T)} is not registered in ViewFactory");
            return UnityEngine.Object.Instantiate(prefab, _canvas.transform);
        }

        protected abstract T GetPrefabOrDefault<T>() where T : MonoBehaviour;
    }
}
