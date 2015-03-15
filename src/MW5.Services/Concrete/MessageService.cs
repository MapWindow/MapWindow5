using System.Windows.Forms;
using MW5.Plugins.Services;

namespace MW5.Services.Concrete
{
    public class MessageService: IMessageService
    {
        private const string AppName = "MapWindow 5";

        public void Warn(string message)
        {
            MessageBox.Show(message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Info(string message)
        {
            MessageBox.Show(message, AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool Ask(string message)
        {
            return MessageBox.Show(message, AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                   DialogResult.Yes;
        }

        public DialogResult AskWithCancel(string message)
        {
            return MessageBox.Show(message, AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
