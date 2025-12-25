using IS.Core.Views;
using IS.Data;
using IS.Data.Configs;
using IS.Infrastracture;

namespace IS.Core.Factories
{
    public class InventoryItemViewFactory : BaseItemViewFactory<ItemView<ItemData>, ItemData>
    {
        protected override ItemView<ItemData> _prefab { get; }

        public InventoryItemViewFactory() 
        {
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<ItemViewPrefabsConfig>();
            _prefab = config.inventoryItemView;
        }
    }
}
