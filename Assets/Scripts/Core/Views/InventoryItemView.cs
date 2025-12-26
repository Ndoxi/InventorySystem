using IS.Data;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public class InventoryItemView : ItemView<ItemData>
    {
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
            Debug.Log($"Request to use item: {_runtimeData.data.itemName}");
        }
    }
}