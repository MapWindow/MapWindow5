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
        bool ShowChildView(Form form, bool modal = true);
        bool ShowChildView(Form form, IWin32Window parent, bool modal = true);
        void Update();
        IWin32Window MainForm { get; }
        void Lock();
        void Unlock();
    }
}
