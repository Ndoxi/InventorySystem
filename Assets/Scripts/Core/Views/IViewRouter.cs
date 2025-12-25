using IS.Core.Factories;
using IS.Infrastracture;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace IS.Core.Views
{
    public interface IViewRouter
    {
        T Open<T>() where T : View;
        void Close<T>() where T : View;
    }

    public interface IPopupRouter
    {
        T Open<T>() where T : Popup;
        void Close<T>(T popup) where T : Popup;
    }

    public class PopupRouter : IPopupRouter, IDisposable
    {
        private readonly Canvas _canvas;
        private readonly IFactory<Popup> _popupFactory;
        private readonly List<Popup> _popups = new ();
        private Button _blocker;

        public PopupRouter(Canvas canvas)
        {
            _canvas = canvas;
            _popupFactory = ServiceLocator.Resolve<IFactory<Popup>>();
        }

        public T Open<T>() where T : Popup
        {
            if (_blocker == null)
            {
                _blocker = CreateBlocker();
                _blocker.onClick.AddListener(CloseTopPopup);
            }
            else
            {
                _blocker.gameObject.SetActive(true);
                _blocker.transform.SetAsLastSibling();
            }

            var popup = _popupFactory.Create<T>(); 
            _popups.Add(popup);

            return popup;
        }

        public void Close<T>(T popup) where T : Popup
        {
            _popups.Remove(popup);
            UpdateBlocker();
        }

        public void Dispose()
        {
            _blocker.onClick.RemoveListener(CloseTopPopup);
        }

        private void CloseTopPopup()
        {
            if (_popups.Count == 0)
                return;
            var topPopup = _popups[^1];
            _popups.RemoveAt(_popups.Count - 1);
            topPopup.Hide();
            UpdateBlocker();
        }

        private void UpdateBlocker()
        {
            if (_popups.Count > 0)
                _blocker.transform.SetSiblingIndex(_popups.Count - 1);
            else
                _blocker.gameObject.SetActive(false);
        }

        private Button CreateBlocker()
        {
            var blockerObject = new GameObject("Blocker");
            blockerObject.transform.SetParent(_canvas.transform);
            var rectTransform = blockerObject.AddComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            var button = blockerObject.AddComponent<Button>();
            var image = blockerObject.AddComponent<Image>();
            image.color = new Color(0, 0, 0, 0.5f);
            return button;
        }
    }
}