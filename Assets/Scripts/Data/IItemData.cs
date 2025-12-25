using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    public interface IItemData
    {
        string itemName { get; }
        Sprite icon { get; }
        string description { get; }
        IItem ToRuntime();
    }
}
