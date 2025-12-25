using UnityEngine;

namespace IS.Data.Configs
{
    [CreateAssetMenu(fileName = "ScriptableObjectsProviderConfig", menuName = "Scriptable Objects/ScriptableObjectsProviderConfig")]
    public class ScriptableObjectsProviderConfig : ScriptableObject
    {
        public ScriptableObject[] configs => _configs;

        [SerializeField] private ScriptableObject[] _configs;
    }
}