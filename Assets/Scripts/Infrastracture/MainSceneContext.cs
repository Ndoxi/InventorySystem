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
            ServiceLocator.Register<IFactory<View>>(new ViewFactory(_viewCanvas));
            ServiceLocator.Register<IFactory<Popup>>(new PopupFactory(_popupCanvas));
            ServiceLocator.Register<IViewRouter>(new ViewRouter());
            ServiceLocator.Register<IPopupRouter>(new PopupRouter(_popupCanvas));
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IFactory<View>>();
            ServiceLocator.Unregister<IFactory<Popup>>();
            ServiceLocator.Unregister<IViewRouter>();
            ServiceLocator.Unregister<IPopupRouter>();
        }
    }
}
