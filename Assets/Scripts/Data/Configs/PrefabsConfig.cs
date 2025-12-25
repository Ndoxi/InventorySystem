using System.Collections.Generic;
using UnityEngine;

namespace IS.Data.Configs
{
    public class PrefabsConfig<T> : ScriptableObject where T : Object
    {
        public T[] prefabs => _prefabs;
        [SerializeField] private T[] _prefabs;
    }
}
