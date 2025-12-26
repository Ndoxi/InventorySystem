using IS.Core.Factories;
using IS.Core.Models;
using IS.Core.Views;
using IS.Data;
using IS.Data.Configs;
using IS.Services;
using System;
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
            InstallServices();
            InstallFactories();
            InstallRouters();
            InstallModels();
        }

        private void InstallServices()
        {
            ServiceLocator.Register<IInventoryService>(new PlayerInventoryModel());
        }

        private void InstallFactories()
        {
            ServiceLocator.Register<IItemViewFactory<InventoryItemView, ItemData>>(new InventoryItemViewFactory());
            ServiceLocator.Register<IItemViewFactory<ShopItemView, ShopItemData>>(new ShopItemViewFactory());
            ServiceLocator.Register<IViewFactory<View>>(new ViewFactory(_viewCanvas));
            ServiceLocator.Register<IViewFactory<Popup>>(new PopupFactory(_popupCanvas));
        }

        private void InstallRouters()
        {
            ServiceLocator.Register<IViewRouter>(new ViewRouter());
            ServiceLocator.Register<IPopupRouter>(new PopupRouter(_popupCanvas));
        }

        private void InstallModels()
        {
            ServiceLocator.Register<ICurrencyModel>(new CurrencyModel());
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IInventoryService>();
            ServiceLocator.Unregister<IItemViewFactory<InventoryItemView, ItemData>>();
            ServiceLocator.Unregister<IItemViewFactory<ShopItemView, ShopItemData>>();
            ServiceLocator.Unregister<IViewFactory<View>>();
            ServiceLocator.Unregister<IViewFactory<Popup>>();
            ServiceLocator.Unregister<IViewRouter>();
            ServiceLocator.Unregister<IPopupRouter>();
            ServiceLocator.Unregister<ICurrencyModel>();
        }
    }
}
