using IS.Core.Factories;
using IS.Core.Views;
using IS.Data;
using IS.Data.Configs;
using UnityEngine;

namespace IS.Infrastracture
{
    public class MainSceneContext : IContext
    {
        private readonly Canvas _viewCanvas;
        private readonly Canvas _popupCanvas;

        public MainSceneContext(Canvas viewCanvas, Canvas popupCanvas) 
        {
            _viewCanvas = viewCanvas;
            _popupCanvas = popupCanvas;
        }

        public void Install()
        {
            InstallFactories();
            InstallRouters();
        }

        private void InstallFactories()
        {
            ServiceLocator.Register<IItemViewFactory<ItemView<ItemData>, ItemData>>(new InventoryItemViewFactory());
            ServiceLocator.Register<IItemViewFactory<ItemView<ShopItemData>, ShopItemData>>(new ShopItemViewFactory());
            ServiceLocator.Register<IViewFactory<View>>(new ViewFactory(_viewCanvas));
            ServiceLocator.Register<IViewFactory<Popup>>(new PopupFactory(_popupCanvas));
        }

        private void InstallRouters()
        {
            ServiceLocator.Register<IViewRouter>(new ViewRouter());
            ServiceLocator.Register<IPopupRouter>(new PopupRouter(_popupCanvas));
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IItemViewFactory<ItemView<ItemData>, ItemData>>();
            ServiceLocator.Unregister<IItemViewFactory<ItemView<ShopItemData>, ShopItemData>>();
            ServiceLocator.Unregister<IViewFactory<View>>();
            ServiceLocator.Unregister<IViewFactory<Popup>>();
            ServiceLocator.Unregister<IViewRouter>();
            ServiceLocator.Unregister<IPopupRouter>();
        }
    }
}
