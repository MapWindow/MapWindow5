using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Services;

namespace MW5.Services.Concrete
{
    internal class FlexibleMessageService: IMessageService
    {
        public FlexibleMessageService()
        {
            MessageService.Current = this;
        }

        public void Warn(string message)
        {
            FlexibleMessageBox.Show(message, MessageService.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Info(string message)
        {
            FlexibleMessageBox.Show(message, MessageService.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool Ask(string message)
        {
            return FlexibleMessageBox.Show(message, MessageService.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public DialogResult AskWithCancel(string message)
        {
            return FlexibleMessageBox.Show(message, MessageService.AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
