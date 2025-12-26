using IS.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IS.Core.Views
{
    public class PlayerInventoryView : InventoryView<ItemData>
    {
        public event Action<IRuntimeItemData<ItemData>> useRequested;

        [SerializeField] private InventoryGridView _inventoryGridView;

        protected override void OnEnable()
        {
            base.OnEnable();

            _inventoryGridView.useRequested += OnUseRequested;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _inventoryGridView.useRequested -= OnUseRequested;
        }

        public override void Init(IRuntimeItemData<ItemData>[] datas)
        {
            _inventoryGridView.Init(datas);
        }

        public override void Add(IRuntimeItemData<ItemData> data)
        {
            _inventoryGridView.Add(data);
        }

        public override void Remove(IRuntimeItemData<ItemData> data)
        {
            _inventoryGridView.Remove(data);
        }

        public void Actialize(IRuntimeItemData<ItemData>[] datas)
        {
            _inventoryGridView.Actualize(datas);
        }

        private void OnUseRequested(IRuntimeItemData<ItemData> runtimeItemData)
        {
            useRequested?.Invoke(runtimeItemData);
        }
    }
}