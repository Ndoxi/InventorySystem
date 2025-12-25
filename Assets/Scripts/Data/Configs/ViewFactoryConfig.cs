using IS.Core.Views;
using System.Collections.Generic;
using UnityEngine;

namespace IS.Data.Configs
{
    [CreateAssetMenu(fileName = "ViewFactoryConfig", menuName = "Scriptable Objects/ViewFactoryConfig")]
    public class ViewFactoryConfig : ScriptableObject
    {
        public List<View> prefabs => _prefabs;

        [SerializeField] private List<View> _prefabs;
    }
}
