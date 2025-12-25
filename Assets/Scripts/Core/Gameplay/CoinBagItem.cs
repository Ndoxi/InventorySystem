using UnityEngine;

namespace IS.Core.Gameplay.Items
{
    public class CoinBagItem : IItem
    {
        private readonly int _amount;

        public CoinBagItem(int amount)
        {
            _amount = amount;
        }

        public void Use()
        {
            Debug.Log($"Used a coin bag with {_amount} coins.");
        }
    }
}
