using IS.Core.Views;
using UnityEngine;

namespace IS.Data.Configs
{
    [CreateAssetMenu(fileName = "ItemViewPrefabsConfig", menuName = "Scriptable Objects/ItemViewPrefabsConfig")]
    public class ItemViewPrefabsConfig : ScriptableObject 
    {
        public InventoryItemView inventoryItemView => _inventoryItemView;
        public ShopItemView shopItemView => _shopItemView;

        [SerializeField] private InventoryItemView _inventoryItemView;
        [SerializeField] private ShopItemView _shopItemView;
    }
}
