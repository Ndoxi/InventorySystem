using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IS.Core.Gameplay
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointerEventData> clicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            clicked?.Invoke(eventData);
        }
    }
}
