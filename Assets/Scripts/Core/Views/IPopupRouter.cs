namespace IS.Core.Views
{
    public interface IPopupRouter
    {
        T Open<T>() where T : Popup;
        void Close<T>(T popup) where T : Popup;
    }
}