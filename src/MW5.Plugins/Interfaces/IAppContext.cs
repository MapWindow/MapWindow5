using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;

namespace MW5.Plugins.Interfaces
{
    public interface IAppContext
    {
        IMapControl Map { get; }
        ILegendControl Legend { get; }
        IWin32Window MainWindow { get; }
        IMenu Menu { get; }
        IToolbarCollection Toolbars { get; }
        bool Initialized { get; }
        void Init(IMainForm form);
    }
}
