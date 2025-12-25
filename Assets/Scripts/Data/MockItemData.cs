using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "MockItemData", menuName = "Scriptable Objects/Data/MockItemData")]
    public class MockItemData : ItemData
    {
        public override IItem ToRuntime()
        {
            return new MockItem();
        }
    }
}
