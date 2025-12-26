using IS.Core.Gameplay.Items;
using System.Linq.Expressions;
using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "ShopItemData", menuName = "Scriptable Objects/Data/ShopItemData")]
    public class ShopItemData : ScriptableObject, IItemData
    {
        public string itemName => _item.itemName;
        public Sprite icon => _item.icon;
        public string description => _item.description;
        public int price => _price;

        [SerializeField] private ItemData _item;
        [SerializeField] private int _price;

        public IItem ToRuntimeItem()
        {
            return _item.ToRuntimeItem();
        }
    }
}
