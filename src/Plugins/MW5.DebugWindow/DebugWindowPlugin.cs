// -------------------------------------------------------------------------------------------
// <copyright file="DebugWindowPlugin.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Plugins.DebugWindow.Menu;
using MW5.Plugins.DebugWindow.Services;
using MW5.Plugins.DebugWindow.Views;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.DebugWindow
{
    /// <summary>
    /// The debug window plugin.
    /// </summary>
    [MapWindowPlugin]
    public class DebugWindowPlugin : BasePlugin
    {
        private IAppContext _context;
        private DockPanelService _dockPanelService;
        private DebugPresenter _presenter;
        private StatusBarListener _statusBarListener;

        /// <summary>
        /// The initialize method, called when the plug-in is loaded
        /// </summary>
        public override void Initialize(IAppContext context)
        {
            _context = context;

            _presenter = context.Container.GetInstance<DebugPresenter>();
            _dockPanelService = context.Container.GetInstance<DockPanelService>();
            _statusBarListener = context.Container.GetInstance<StatusBarListener>();
        }

        /// <summary>
        /// Set up container for dependency injection:
        /// </summary>
        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }
    }
}