using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Interfaces
{
    public interface IAppView
    {
        bool ShowDialog(Form form);
        bool ShowDialog(Form form, IWin32Window parent);
        void Update();
    }
}
