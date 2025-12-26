using IS.Core.Gameplay.Items;
using IS.Data;
using IS.Services;

namespace IS.Core.Models
{
    public class PlayerInventoryModel : InventoryModel<ItemData>, IInventoryService
    {
        public void Use(IRuntimeItemData<ItemData> runtimeItemData)
        {
            IItem runtimeItem = runtimeItemData.data.ToRuntimeItem();
            runtimeItem.Use();
        }
    }
}
