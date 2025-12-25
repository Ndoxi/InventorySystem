using IS.Core.Views;

namespace IS.Core.Factories
{
    public interface IItemViewFactory<TItem> where TItem : class
    {
        T Create<T>() where T : class, TItem;
    }
}
