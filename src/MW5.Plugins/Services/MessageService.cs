using System.Windows.Forms;

namespace MW5.Plugins.Services
{
    public class MessageService: IMessageService
    {
        public const string AppName = "MapWindow 5";
        private static IMessageService _service;

        public static IMessageService Current
        {
            get { return _service ?? (_service = new MessageService()); }
            set { _service = value; }
        }

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
            return MessageBox.Show(message, AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public DialogResult AskWithCancel(string message)
        {
            return MessageBox.Show(message, AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
