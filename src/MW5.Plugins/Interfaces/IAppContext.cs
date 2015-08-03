using System.Threading;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces.Projections;
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
        ILayerCollection<ILayer> Layers { get; }
        IDockPanelCollection DockPanels { get; }
        IProjectionDatabase Projections { get; }
        AppConfig Config { get; }       // TODO: extract interface later
        ILocator Locator { get; }
        IToolbox Toolbox { get; }
        ITaskCollection Tasks { get; }
        IRepository Repository { get; }
        SynchronizationContext SynchronizationContext { get; }
        void SetMapProjection(ISpatialReference projection);
        bool Initialized { get; }
    }
}
