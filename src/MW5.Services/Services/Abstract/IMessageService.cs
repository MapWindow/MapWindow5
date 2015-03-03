namespace MW5.Services.Abstract
{
    public interface IMessageService
    {
        void Warn(string message);
        void Info(string message);
        bool Ask(string message);
    }
}
