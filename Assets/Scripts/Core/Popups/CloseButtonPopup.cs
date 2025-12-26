using IS.Core.Views;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Popups
{
    public class CloseButtonPopup : Popup
    {
        [SerializeField] private Button _closeButton;

        protected virtual void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        protected virtual void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }
    }
}
