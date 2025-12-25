using IS.Core.Views;
using IS.Infrastracture;
using UnityEditor;
using UnityEngine;

namespace IS.Core.Mediators
{
    [RequireComponent(typeof(HudButtonsView))]
    public class HudButtonsMediator : Mediator<HudButtonsView>
    {
        private IViewRouter _viewRouter;

        private void Start()
        {
            _viewRouter = ServiceLocator.Resolve<IViewRouter>();
        }

        private void OnEnable()
        {
            _view.shopRequested += ShowShop;
            _view.inventoryRequested += ShowInventory;
        }

        private void OnDisable()
        {
            _view.shopRequested -= ShowShop;
            _view.inventoryRequested -= ShowInventory;
        }

        private void ShowShop()
        {
            _viewRouter.Open<ShopView>();
        }

        private void ShowInventory()
        {
            _viewRouter.Open<InventoryView>();
        }
    }
}

