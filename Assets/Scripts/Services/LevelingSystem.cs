using IS.Core.Gameplay;
using IS.Data.Configs;
using IS.Infrastracture;
using System;

namespace IS.Services
{
    public class LevelingSystem : ILevelingSystem
    {
        public event Action<int> levelUpdated;
        public event Action<int> xpUpdated;

        public int currentLevel { get; private set; }
        public int currentXp { get; private set; }
        public int nextLevelXp { get; private set; }

        private readonly int _nextLevelXpMultiplier;
        private int _xpBonus;

        public LevelingSystem()
        {
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<LevelingSystemConfig>();

            currentLevel = config.initialLevel;
            nextLevelXp = config.initialNextLevelXp;
            _nextLevelXpMultiplier = config.nextLevelXpMultiplier;
        }

        public void AddXp(int amount)
        {
            currentXp += amount + _xpBonus;
            xpUpdated?.Invoke(currentXp);

            if (currentXp >= nextLevelXp)
            {
                currentXp -= nextLevelXp;
                currentLevel++;
                nextLevelXp *= _nextLevelXpMultiplier;
                levelUpdated?.Invoke(currentLevel);
            }
        }

        public void AddXpBonus(int bonus)
        {
            _xpBonus += bonus;
        }
    }
}
