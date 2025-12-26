using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "XpBonusItemData", menuName = "Scriptable Objects/Data/XpBonusItemData")]
    public class XpBonusItemData : ItemData
    {
        [SerializeField] private int bonus;

        public override IItem ToRuntimeItem()
        {
            return new XpBonusItem(bonus);
        }
    }
}
