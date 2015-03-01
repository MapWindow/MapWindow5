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
    }
}
