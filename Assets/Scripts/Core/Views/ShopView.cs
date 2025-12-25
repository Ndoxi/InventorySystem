using IS.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class ShopView : View 
    {
        public event Action exitRequested;

        [SerializeField] ShopGridView _shopGridView;
        [SerializeField] private Button _exitButton;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(CloseView);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(CloseView);
        }

        public void Init(ShopItemData[] datas)
        {
            _shopGridView.Init(datas);
        }

        private void CloseView()
        {
            exitRequested?.Invoke();
        }
    }
}