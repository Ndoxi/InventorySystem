using System.Collections.Generic;
using UnityEngine;

namespace IS.Data.Configs
{
    public class PrefabsConfig<T> : ScriptableObject where T : MonoBehaviour
    {
        public List<T> prefabs => _prefabs;
        [SerializeField] private List<T> _prefabs;
    }
}
