// -------------------------------------------------------------------------------------------
// <copyright file="IAppContext.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Threading;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Interfaces
{
    public interface IAppContext
    {
        AppConfig Config { get; }

        IApplicationContainer Container { get; }

        IDockPanelCollection DockPanels { get; }

        ILayerCollection<ILayer> Layers { get; }

        IMuteLegend Legend { get; }

        ILocator Locator { get; }

        IMuteMap Map { get; }

        IMenu Menu { get; }

        IProject Project { get; }

        IProjectionDatabase Projections { get; }

        IRepository Repository { get; }

        IStatusBar StatusBar { get; }

        SynchronizationContext SynchronizationContext { get; }

        ITaskCollection Tasks { get; }

        IToolbarCollection Toolbars { get; }

        IToolbox Toolbox { get; }

        IAppView View { get; }

        bool Initialized { get; }

        void SetMapProjection(ISpatialReference projection);
    }
}