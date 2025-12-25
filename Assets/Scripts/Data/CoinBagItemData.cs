using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "CoinBagItemData", menuName = "Scriptable Objects/Data/CoinBagItemData")]
    public class CoinBagItemData : ItemData
    {
        [SerializeField] private int _amount;

        public override IItem ToRuntime()
        {
            return new CoinBagItem(_amount);
        }
    }
}
