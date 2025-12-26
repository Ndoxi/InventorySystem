using UnityEngine;

namespace IS.Data.Configs
{
    [CreateAssetMenu(fileName = "LevelingSystemConfig", menuName = "Scriptable Objects/LevelingSystemConfig")]
    public class LevelingSystemConfig : ScriptableObject
    {
        public int initialLevel => _initialLevel;
        public int initialNextLevelXp => _initialNextLevelXp;
        public int nextLevelXpMultiplier => _nextLevelXpMultiplier;

        [SerializeField] private int _initialLevel = 1;
        [SerializeField] private int _initialNextLevelXp = 5;
        [SerializeField] private int _nextLevelXpMultiplier = 2;
    }
}