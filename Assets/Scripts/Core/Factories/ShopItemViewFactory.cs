using IS.Core.Views;
using IS.Data;
using IS.Data.Configs;
using IS.Infrastracture;

namespace IS.Core.Factories
{
    public class ShopItemViewFactory : BaseItemViewFactory<ShopItemView, ShopItemData>
    {
        protected override ShopItemView _prefab { get; }

        public ShopItemViewFactory()
        {
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<ItemViewPrefabsConfig>();
            _prefab = config.shopItemView;
        }
    }
}
