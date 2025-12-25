namespace IS.Core.Views
{
    public interface IViewRouter
    {
        T Open<T>() where T : class, IView;
        void Close<T>() where T : class, IView;
    }
}