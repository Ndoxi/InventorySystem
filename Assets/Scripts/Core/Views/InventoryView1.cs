using IS.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class InventoryView : View
    {
        public event Action exitRequested;

        [SerializeField] private Button _exitButton;

        protected virtual void OnEnable()
        {
            _exitButton.onClick.AddListener(CloseView);
        }

        protected virtual void OnDisable()
        {
            _exitButton.onClick.RemoveListener(CloseView);
        }

        public virtual void Init(IRuntimeItemData<ShopItemData>[] datas) { }

        public virtual void Remove(IRuntimeItemData<ShopItemData> data) { }

        private void CloseView()
        {
            exitRequested?.Invoke();
        }
    }
}