using System.Windows.Forms;

namespace MW5.Services.Services.Abstract
{
    public interface IMessageService
    {
        void Warn(string message);
        void Info(string message);
        bool Ask(string message);
        DialogResult AskWithCancel(string message);
    }
}
