using System;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class HudButtonsView : View
    {
        public event Action shopRequested;
        public event Action inventoryRequested;

        [SerializeField] private Button _openShopButton;
        [SerializeField] private Button _openInventoryButton;

        private void OnEnable()
        {
            _openShopButton.onClick.AddListener(OpenShop);
            _openInventoryButton.onClick.AddListener(OpenInventory);
        }

        private void OnDisable()
        {
            _openShopButton.onClick.RemoveListener(OpenShop);
            _openInventoryButton.onClick.RemoveListener(OpenInventory);
        }

        private void OpenShop()
        {
            shopRequested?.Invoke();
        }

        private void OpenInventory() 
        {
            inventoryRequested?.Invoke();
        }
    }
}