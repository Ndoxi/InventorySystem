using IS.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class ShopItemView : ItemView<ShopItemData>
    {
        [SerializeField] private TextMeshProUGUI _priceTextMesh;
        [SerializeField] private Button _buyButton;

        private void OnEnable()
        {
            _buyButton.onClick.AddListener(RequestBuy);
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveListener(RequestBuy);
        }

        private void RequestBuy()
        {
            Debug.Log($"Request to buy item: {_data.itemName} for {_data.price}");
        }
    }
}