using IS.Core.Views;
using IS.Infrastracture;
using IS.Services;
using UnityEngine;

namespace IS.Core.Mediators
{
    [RequireComponent(typeof(HudLevelView))]
    public class HudLevelMediator : Mediator<HudLevelView> 
    {
        private ILevelingSystem _levelingSystem;

        protected override void Awake()
        {
            base.Awake();
            _levelingSystem = ServiceLocator.Resolve<ILevelingSystem>();
        }

        private void Start()
        {
            _view.OnXpUpdated(_levelingSystem.currentXp, _levelingSystem.nextLevelXp);
        }

        private void OnEnable()
        {
            _levelingSystem.levelUpdated += OnLevelUpdated;
            _levelingSystem.xpUpdated += OnXpUpdated;
        }

        private void OnDisable()
        {
            _levelingSystem.levelUpdated -= OnLevelUpdated;
            _levelingSystem.xpUpdated -= OnXpUpdated;
        }

        private void OnLevelUpdated(int level)
        {
            _view.OnLevelUpdated(level, _levelingSystem.currentXp, _levelingSystem.nextLevelXp);
        }

        private void OnXpUpdated(int currentXp)
        {
            _view.OnXpUpdated(currentXp, _levelingSystem.nextLevelXp);
        }
    }
}

