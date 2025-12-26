using UnityEngine;

namespace IS.Data.Configs
{
    [CreateAssetMenu(fileName = "RewardSystemConfig", menuName = "Scriptable Objects/RewardSystemConfig")]
    public class RewardSystemConfig : ScriptableObject
    {
        public int rewardLevelMultiplier => _rewardLevelMultiplier;

        [SerializeField] private int _rewardLevelMultiplier = 3;
    }
}