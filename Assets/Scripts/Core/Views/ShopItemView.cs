using IS.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class ShopItemView : ItemView<ShopItemData>
    {
        private const string ButtonText = "Buy {0}";

        public event Action<IRuntimeItemData<ShopItemData>> buyRequested;

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

        protected override void UpdateView()
        {
            base.UpdateView();
            _priceTextMesh.text = string.Format(ButtonText, _runtimeData.data.price);
        }

        private void RequestBuy()
        {
            buyRequested?.Invoke(_runtimeData);
        }
    }
}