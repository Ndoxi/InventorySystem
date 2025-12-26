using IS.Data;
using System;
using UnityEngine;

namespace IS.Core.Views
{
    public class ShopView : InventoryView<ShopItemData>
    {
        public event Action<IRuntimeItemData<ShopItemData>> buyRequested;

        [SerializeField] private ShopGridView _shopGridView;

        protected override void OnEnable()
        {
            base.OnEnable();
            _shopGridView.buyRequested += RequestBuy;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _shopGridView.buyRequested -= RequestBuy;
        }

        public override void Init(IRuntimeItemData<ShopItemData>[] datas)
        {
            _shopGridView.Init(datas);
        }

        public override void Add(IRuntimeItemData<ShopItemData> data)
        {
            _shopGridView.Add(data);
        }

        public override void Remove(IRuntimeItemData<ShopItemData> data)
        {
            _shopGridView.Remove(data);
        }

        private void RequestBuy(IRuntimeItemData<ShopItemData> data)
        {
            buyRequested?.Invoke(data);
        }
    }
}