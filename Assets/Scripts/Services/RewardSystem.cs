using IS.Data.Configs;
using IS.Infrastracture;

namespace IS.Services
{
    public class RewardSystem : IRewardSystem
    {
        private readonly int _rewardLevelMultiplier;

        public RewardSystem()
        {
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<RewardSystemConfig>();
            _rewardLevelMultiplier = config.rewardLevelMultiplier;
        }

        public int GetLevelUpReward(int level)
        {
            return level * _rewardLevelMultiplier;
        }
    }
}
