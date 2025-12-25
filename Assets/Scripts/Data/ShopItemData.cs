using UnityEngine;

namespace IS.Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/Data/ShopItemData")]
    public class ShopItemData : ScriptableObject
    {
        [SerializeField] private ItemData _item;
        [SerializeField] private int _price;
    }
}
