using IS.Core.Factories;
using IS.Core.Views;
using UnityEngine;

namespace IS.Infrastracture
{
    public class MainSceneContext : IContext
    {
        private readonly Canvas _viewCanvas;

        public MainSceneContext(Canvas viewCanvas) 
        {
            _viewCanvas = viewCanvas;
        }

        public void Install()
        {
            ServiceLocator.Register<IViewFactory>(new ViewFactory(_viewCanvas));
            ServiceLocator.Register<IViewRouter>(new ViewRouter());
        }

        public void Uninstall()
        {
            ServiceLocator.Unregister<IViewFactory>();
            ServiceLocator.Unregister<IViewRouter>();
        }
    }
}
