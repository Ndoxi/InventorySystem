namespace IS.Core.Views
{
    public interface IViewRouter
    {
        T Open<T>() where T : View;
        void Close<T>() where T : View;
    }
}