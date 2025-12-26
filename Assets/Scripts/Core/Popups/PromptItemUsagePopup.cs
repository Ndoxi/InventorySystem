using IS.Core.Views;
using IS.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Popups
{
    public class PromptItemUsagePopup : Popup
    {
        private const string Text = "Do you want to use {0}?";

        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _declineButton;

        private IRuntimeItemData<ItemData> _runtimeItemData;
        private Action<IRuntimeItemData<ItemData>> _onAccept;
        private Action _onDecline;

        public void Init(IRuntimeItemData<ItemData> runtimeItemData,
                         Action<IRuntimeItemData<ItemData>> onAccept = null,
                         Action onDecline = null)
        {
            _runtimeItemData = runtimeItemData;
            _onAccept = onAccept;
            _onDecline = onDecline;

            _textMesh.text = string.Format(Text, _runtimeItemData.data.itemName);
        }

        private void OnEnable()
        {
            _acceptButton.onClick.AddListener(Accept);
            _declineButton.onClick.AddListener(Decline);
        }

        private void OnDisable()
        {
            _acceptButton.onClick.RemoveListener(Accept);
            _declineButton.onClick.RemoveListener(Decline);
        }

        private void Accept()
        {
            _onAccept?.Invoke(_runtimeItemData);
            Close();
        }

        private void Decline()
        {
            _onDecline?.Invoke();
            Close();
        }
    }
}
