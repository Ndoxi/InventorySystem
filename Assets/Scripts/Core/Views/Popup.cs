using IS.Infrastracture;
using UnityEngine;

namespace IS.Core.Views
{
    public abstract class Popup : MonoBehaviour, IPanel
    {
        protected IPopupRouter _popupRouter;

        private void Start()
        {
            _popupRouter = ServiceLocator.Resolve<IPopupRouter>();
        }

        public void Show()
        {
            //animation could be added here
        }

        public void Hide()
        {
            Destroy(gameObject);
        }

        protected void Close()
        {
            _popupRouter.Close(this);
        }
    }
}