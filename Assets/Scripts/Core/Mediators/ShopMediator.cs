using IS.Core.Models;
using IS.Core.Views;
using IS.Data;
using IS.Infrastracture;
using System.Linq;
using UnityEngine;

namespace IS.Core.Mediators
{
    [RequireComponent(typeof(ShopView))]
    public class ShopMediator : Mediator<ShopView, ShopModel>
    {
        private IViewRouter _viewRouter;
        private ShopModel _model;

        private void Start()
        {
            _viewRouter = ServiceLocator.Resolve<IViewRouter>();
            _view.Init(_model.items.ToArray());
        }

        private void OnEnable()
        {
            _view.buyRequested += OnBuyRequested;
            _view.exitRequested += CloseView;
            _model.itemRemoved += OnItemRemoved;
        }

        private void OnDisable()
        {
            _view.buyRequested -= OnBuyRequested;
            _view.exitRequested -= CloseView;
            _model.itemRemoved -= OnItemRemoved;
        }

        public override void Install(ShopModel model)
        {
            _model = model;
        }

        private void CloseView()
        {
            _viewRouter.Close<ShopView>();
        }

        private void OnBuyRequested(IRuntimeItemData<ShopItemData> runtimeItemData)
        {
            _model.Buy(runtimeItemData);
        }

        private void OnItemRemoved(IRuntimeItemData<ShopItemData> runtimeItemData)
        {
            _view.Remove(runtimeItemData);
        }
    }
}

