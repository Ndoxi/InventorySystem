using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace IS.Data.Configs
{
    public class ArrayConfig<T> : ScriptableObject where T : Object
    {
        public T[] items => _items;
        [SerializeField, FormerlySerializedAs("_prefabs")] private T[] _items;
    }
}
