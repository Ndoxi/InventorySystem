using IS.Infrastracture;
using IS.Services;

namespace IS.Core.Gameplay.Items
{
    public class MultiHitItem : IItem
    {
        public void Use()
        {
            var attackSystem = ServiceLocator.Resolve<IAttackSystem>();
            attackSystem.AddMultiHit();
        }
    }
}