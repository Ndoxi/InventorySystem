using IS.Core.Factories;
using IS.Core.Views;
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
            ServiceLocator.Register<IItemViewFactory<View>>(new ViewFactory(_viewCanvas));
            ServiceLocator.Register<IItemViewFactory<Popup>>(new PopupFactory(_popupCanvas));
            ServiceLocator.Register<IViewRouter>(new ViewRouter());
            ServiceLocator.Register<IPopupRouter>(new PopupRouter(_popupCanvas));
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IItemViewFactory<View>>();
            ServiceLocator.Unregister<IItemViewFactory<Popup>>();
            ServiceLocator.Unregister<IViewRouter>();
            ServiceLocator.Unregister<IPopupRouter>();
        }
    }
}
