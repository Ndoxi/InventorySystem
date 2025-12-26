using IS.Data;
using IS.Data.Configs;
using IS.Infrastracture;

namespace IS.Core.Models
{
    public class RandomizedShopModel : ShopModel
    {
        private const int MinItemsCount = 5;
        private const int MaxItemsCount = 10;

        public RandomizedShopModel(ICurrencyModel currencyModel) : base(currencyModel)
        {
            var config = ServiceLocator.Resolve<IConfigProvider>().Get<ShopItemsConfig>();
            int count = UnityEngine.Random.Range(MinItemsCount, MaxItemsCount + 1);

            _items = new (count);
            for (int i = 0; i < count; i++) 
            {
                int randomIndex = UnityEngine.Random.Range(0, config.items.Length);
                var data = new RuntimeItemData<ShopItemData>(config.items[randomIndex]);
                _items.Add(data);
            }
        }
    }
}
