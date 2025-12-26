using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "MultiHitItem", menuName = "Scriptable Objects/Data/MultiHitItem")]
    public class MultiHitItemData : ItemData
    {
        public override IItem ToRuntimeItem()
        {
            return new MultiHitItem();
        }
    }
}
