using System;

namespace IS.Services
{
    public interface ILevelingSystem
    {
        event Action<int> levelUpdated;
        event Action<int> xpUpdated;
        event Action<int> xpGained;

        int currentLevel { get; }
        int currentXp { get; }
        int nextLevelXp { get; }
        void AddXp(int amount);
        void AddXpBonus(int bonus);
    }
}
