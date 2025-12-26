using IS.Core.Gameplay.Items;
using IS.Core.Models;
using IS.Core.Popups;
using IS.Core.Views;
using IS.Data;
using IS.Infrastracture;
using IS.Services;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace IS.Core.Mediators
{
    [RequireComponent(typeof(PlayerInventoryView))]
    public class PlayerInventoryMediator : Mediator<PlayerInventoryView, IInventoryService>
    {
        private IViewRouter _viewRouter;
        private IPopupRouter _popupRouter;
        private IInventoryService _model;

        protected override void Awake()
        {
            base.Awake();

            _viewRouter = ServiceLocator.Resolve<IViewRouter>();
            _popupRouter = ServiceLocator.Resolve<IPopupRouter>();
            _view.Init(_model.items.ToArray());
        }

        private void OnEnable()
        {
            _view.useRequested += PromptItemUsage;
            _view.exitRequested += CloseView;
            _model.itemAdded += OnItemAdded;
            _model.itemRemoved += OnItemRemoved;

            _view.Actialize(_model.items.ToArray());
        }

        private void OnDisable()
        {
            _view.useRequested -= PromptItemUsage;
            _view.exitRequested -= CloseView;
            _model.itemAdded -= OnItemAdded;
            _model.itemRemoved -= OnItemRemoved;
        }

        public override void Install(IInventoryService model)
        {
            _model = model;
        }

        private void CloseView()
        {
            _viewRouter.Close<PlayerInventoryView>();
        }

        private void OnItemAdded(IRuntimeItemData<ItemData> runtimeItemData)
        {
            _view.Add(runtimeItemData);
        } 

        private void OnItemRemoved(IRuntimeItemData<ItemData> runtimeItemData)
        {
            _view.Remove(runtimeItemData);
        }

        private void PromptItemUsage(IRuntimeItemData<ItemData> runtimeItemData)
        {
            var popup = _popupRouter.Open<PromptItemUsagePopup>();
            popup.Init(runtimeItemData, UseItem);
        }

        private void UseItem(IRuntimeItemData<ItemData> runtimeItemData)
        {
            _model.Use(runtimeItemData);
            _model.Remove(runtimeItemData);
        }
    }
}

