using UnityEngine;

namespace IS.Core.Gameplay.Items
{
    public class PotionItem : IItem
    {
        private readonly float _healAmount;

        public PotionItem(float healAmount)
        {
            _healAmount = healAmount;
        }

        public void Use()
        {
            Debug.Log($"Used a potion that heals {_healAmount} health.");
        }
    }
}
