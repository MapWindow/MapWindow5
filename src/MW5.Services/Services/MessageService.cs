using System.Windows.Forms;
using MW5.Services.Abstract;

namespace MW5.Services
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
    }
}
