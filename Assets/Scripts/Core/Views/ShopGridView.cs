using IS.Data;
using System;

namespace IS.Core.Views
{
    public class ShopGridView : GridView<ShopItemView, ShopItemData> 
    {
        public event Action<IRuntimeItemData<ShopItemData>> buyRequested;

        protected override void RegistedView(ShopItemView view)
        {
            view.buyRequested += RequestBuy;
        }

        protected override void UnregistedView(ShopItemView view)
        {
            view.buyRequested -= RequestBuy;
        }

        private void RequestBuy(IRuntimeItemData<ShopItemData> data) 
        {
            buyRequested?.Invoke(data);
        }
    }
}