using IS.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IS.Core.Views
{
    public class InventoryGridView : GridView<InventoryItemView, ItemData> 
    {
        public event Action<IRuntimeItemData<ItemData>> useRequested;

        public void Actualize(IRuntimeItemData<ItemData>[] datas)
        {
            var actualIds = new HashSet<Guid>(datas.Select(d => d.instanceId));

            foreach (var id in _views.Keys.ToArray())
            {
                if (!actualIds.Contains(id))
                    RemoveById(id);
            }

            foreach (var data in datas)
            {
                if (!_views.ContainsKey(data.instanceId))
                    Add(data);
            }
        }

        protected override void RegistedView(InventoryItemView view)
        {
            view.useRequested += OnUseRequested;
        }

        protected override void UnregistedView(InventoryItemView view)
        {
            view.useRequested -= OnUseRequested;
        }

        private void OnUseRequested(IRuntimeItemData<ItemData> runtimeItemData)
        {
            useRequested?.Invoke(runtimeItemData);
        }
    }
}