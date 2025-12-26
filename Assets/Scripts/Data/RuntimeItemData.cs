using System;

namespace IS.Data
{
    public class RuntimeItemData<T> : IRuntimeItemData<T> where T : IItemData
    {
        public Guid instanceId { get; }
        public T data { get; }

        public RuntimeItemData(T data)
        {
            instanceId = Guid.NewGuid();
            this.data = data;
        }
    }
}
