using IS.Core.Models;
using IS.Core.Views;
using IS.Infrastracture;
using System;
using UnityEngine;

namespace IS.Core.Mediators
{
    [RequireComponent(typeof(HudGoldView))]
    public class HudGoldMediator : Mediator<HudGoldView>
    {
        private ICurrencyModel _currency;

        protected override void Awake()
        {
            base.Awake();
            _currency = ServiceLocator.Resolve<ICurrencyModel>();
            _view.UpdateGold(_currency.amount);
        }

        private void OnEnable()
        {
            _currency.updated += OnUpdate;
        }

        private void OnDisable()
        {
            _currency.updated -= OnUpdate;
        }

        private void OnUpdate(int value)
        {
            _view.UpdateGold(value);
        }
    }
}

