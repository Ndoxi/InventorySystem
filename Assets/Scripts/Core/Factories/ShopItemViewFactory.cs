using IS.Core.Views;
using IS.Data;
using IS.Data.Configs;
using IS.Infrastracture;

namespace IS.Core.Factories
{
    public class ShopItemViewFactory : BaseItemViewFactory<ItemView<ShopItemData>, ShopItemData>
    {
        protected override ItemView<ShopItemData> _prefab { get; }

        public ShopItemViewFactory()
        {
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<ItemViewPrefabsConfig>();
            _prefab = config.shopItemView;
        }
    }
}
