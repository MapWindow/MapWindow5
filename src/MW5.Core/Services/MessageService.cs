using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Core.Services.Abstract;

namespace MW5.Core.Services
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
