using System;

namespace IS.Data
{
    public interface IRuntimeItemData<T> where T : IItemData
    {
        Guid instanceId { get; }   
        T data { get; }
    }
}
