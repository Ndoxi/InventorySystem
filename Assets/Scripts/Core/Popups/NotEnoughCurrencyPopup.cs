using IS.Core.Views;
using IS.Infrastracture;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Popups
{
    public class NotEnoughCurrencyPopup : Popup 
    {
        [SerializeField] private Button _closeButton;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _popupRouter.Close(this);
        }
    }
}
