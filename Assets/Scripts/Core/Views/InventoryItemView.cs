using IS.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class InventoryItemView : ItemView<ItemData>
    {
        public event Action<IRuntimeItemData<ItemData>> useRequested;

        [SerializeField] private Button _useButton;

        private void OnEnable()
        {
            _useButton.onClick.AddListener(RequestUse);
        }

        private void OnDisable()
        {
            _useButton.onClick.RemoveListener(RequestUse);
        }

        private void RequestUse()
        {
            useRequested?.Invoke(_runtimeData);
        }
    }
}