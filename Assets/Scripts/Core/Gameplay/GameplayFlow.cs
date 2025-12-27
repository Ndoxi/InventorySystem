using IS.Core.Models;
using IS.Core.Views;
using IS.Infrastracture;
using IS.Services;
using UnityEngine;

namespace IS.Core.Gameplay
{
    public class GameplayFlow : MonoBehaviour
    {
        private const int BaseXpPerHit = 1;

        [SerializeField] private TrainingDummyView _trainingDummy;
        [SerializeField] private XpParticleSystem _xpParticleSystem;

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
            _levelingSystem.xpGained += EmitXpParticle;
        }

        private void OnDisable()
        {
            _trainingDummy.clicked -= AttackDummy;
            _trainingDummy.hit -= OnHit;
            _levelingSystem.levelUpdated -= OnLevelUp;
            _levelingSystem.xpGained -= EmitXpParticle;
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
            _levelingSystem.AddXp(BaseXpPerHit);
        }

        private void EmitXpParticle(int xp)
        {
            _xpParticleSystem.Emit(xp);
        } 
    }
}
