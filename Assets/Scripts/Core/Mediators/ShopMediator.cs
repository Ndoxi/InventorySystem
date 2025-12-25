using IS.Core.Views;
using IS.Infrastracture;
using UnityEngine;

namespace IS.Core.Mediators
{
    [RequireComponent(typeof(ShopView))]
    public class ShopMediator : Mediator<ShopView> 
    {
        private IViewRouter _viewRouter;

        private void Start()
        {
            _viewRouter = ServiceLocator.Resolve<IViewRouter>();
        }

        private void OnEnable()
        {
            _view.exitRequested += CloseView;
        }

        private void OnDisable()
        {
            _view.exitRequested -= CloseView;
        }

        private void CloseView()
        {
            _viewRouter.Close<ShopView>();
        }
    }
}

