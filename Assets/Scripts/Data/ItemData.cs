using IS.Core.Gameplay.Items;
using UnityEngine;

namespace IS.Data
{
    public abstract class ItemData : ScriptableObject
    {
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;

        public abstract IItem ToRuntime();
    }
}
