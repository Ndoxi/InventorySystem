using IS.Infrastracture;
using IS.Services;

namespace IS.Core.Gameplay.Items
{
    public class XpBonusItem : IItem
    {
        private readonly int _bonus;

        public XpBonusItem(int bonus)
        {
            _bonus = bonus;
        }

        public void Use()
        {
            var levelingSystem = ServiceLocator.Resolve<ILevelingSystem>();
            levelingSystem.AddXpBonus(_bonus);
        }
    }
}