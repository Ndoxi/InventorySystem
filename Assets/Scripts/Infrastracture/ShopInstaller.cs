using IS.Core.Mediators;
using IS.Core.Models;
using UnityEngine;

namespace IS.Infrastracture
{
    [RequireComponent(typeof(ShopMediator))]
    public class ShopInstaller : MonoBehaviour, IContextInitializer
    {
        public void Run()
        {
            var currencyModel = ServiceLocator.Resolve<ICurrencyModel>();
            var mediator = GetComponent<ShopMediator>();
            mediator.Install(new RandomizedShopModel(currencyModel));
        }
    }
}
