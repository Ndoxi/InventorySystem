using IS.Data;

namespace IS.Core.Models
{
    public class ShopModel : InventoryModel<ShopItemData>
    {
        private readonly ICurrencyModel _currencyModel;

        public ShopModel(ICurrencyModel currencyModel)
        {
            _currencyModel = currencyModel;
        }

        public bool Buy(IRuntimeItemData<ShopItemData> runtimeItemData)
        {
            if (_currencyModel.amount < runtimeItemData.data.price)
                return false;

            _currencyModel.Remove(runtimeItemData.data.price);
            Remove(runtimeItemData);
            return true;
        }
    }
}
