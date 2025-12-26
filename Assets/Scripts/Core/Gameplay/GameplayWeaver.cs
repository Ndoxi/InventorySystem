using IS.Core.Models;
using IS.Infrastracture;
using IS.Services;
using UnityEngine;

namespace IS.Core.Gameplay
{
    public class GameplayWeaver : MonoBehaviour
    {
        private const int XpPerHit = 1;

        [SerializeField] private TrainingDummyView _trainingDummy;
        private IAttackSystem _attackSystem;
        private ILevelingSystem _levelingSystem;
        private IRewardSystem _rewardSystem;
        private ICurrencyModel _currency;

        private void Awake()
        {
            _attackSystem = ServiceLocator.Resolve<IAttackSystem>();
            _levelingSystem = ServiceLocator.Resolve<ILevelingSystem>();
            _rewardSystem = ServiceLocator.Resolve<IRewardSystem>();
            _currency = ServiceLocator.Resolve<ICurrencyModel>();
        }

        private void OnEnable()
        {
            _trainingDummy.clicked += AttackDummy;
            _trainingDummy.hit += OnHit;
            _levelingSystem.levelUpdated += OnLevelUp;
        }

        private void OnDisable()
        {
            _trainingDummy.clicked -= AttackDummy;
            _trainingDummy.hit -= OnHit;
            _levelingSystem.levelUpdated -= OnLevelUp;
        }

        private void OnLevelUp(int level)
        {
            var reward = _rewardSystem.GetLevelUpReward(level);
            _currency.Add(reward);
        }

        private void AttackDummy()
        {
            _attackSystem.Attack(_trainingDummy);
        }

        private void OnHit()
        {
            _levelingSystem.AddXp(XpPerHit);
        }
    }
}
