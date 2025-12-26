using IS.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class ShopView : View 
    {
        public event Action exitRequested;

        [SerializeField] private ShopGridView _shopGridView;
        [SerializeField] private Button _exitButton;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(CloseView);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(CloseView);
        }

        public void Init(IRuntimeItemData<ShopItemData>[] datas)
        {
            _shopGridView.Init(datas);
        }

        private void CloseView()
        {
            exitRequested?.Invoke();
        }
    }
}