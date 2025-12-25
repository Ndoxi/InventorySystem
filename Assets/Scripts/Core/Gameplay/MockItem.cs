using UnityEngine;

namespace IS.Core.Gameplay.Items
{
    public class MockItem : IItem
    {
        public void Use()
        {
            Debug.Log("Used a mock item. Good job!");
        }
    }
}
