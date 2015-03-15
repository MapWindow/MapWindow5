using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Interfaces
{
    public interface IAppContext
    {
        IMenu Menu { get; }
        IMuteMap Map { get; }
        IAppView View { get; }
        IProject Project { get; }
        IMuteLegend Legend { get; }
        IStatusBar StatusBar { get; }
        IToolbarCollection Toolbars { get; }
        IApplicationContainer Container { get; }
        ILegendLayerCollection<ILayer> Layers { get; }
    }
}
