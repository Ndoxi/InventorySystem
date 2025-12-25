using IS.Core.Views;
using System;
using UnityEngine;

namespace IS.Core.Mediators
{
    public abstract class Mediator<TView> : MonoBehaviour where TView : View
    {
        protected TView _view;

        private void Awake()
        {
            _view = GetComponent<TView>();

            if (_view == null)
                throw new ArgumentNullException(nameof(_view));
        }
    }
}

