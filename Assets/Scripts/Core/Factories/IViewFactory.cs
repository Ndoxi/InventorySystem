using IS.Core.Views;

namespace IS.Core.Factories
{
    public interface IViewFactory
    {
        T Create<T>() where T : class, IView;
    }
}
