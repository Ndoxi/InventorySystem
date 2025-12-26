using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IS.Core.Gameplay
{
    public class TrainingDummyView : MonoBehaviour
    {
        private readonly int HitTriggerHash = Animator.StringToHash("Hit");

        public event Action hit;
        public event Action clicked;

        [SerializeField] private Clickable _clickable;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _clickable.clicked += OnClick;
        }

        private void OnDisable()
        {
            _clickable.clicked -= OnClick;
        }

        private void OnClick(PointerEventData eventData)
        {
            clicked?.Invoke();
        }

        public void OnHit()
        {
            _animator.SetTrigger(HitTriggerHash);
            hit?.Invoke();
        }
    }
}
