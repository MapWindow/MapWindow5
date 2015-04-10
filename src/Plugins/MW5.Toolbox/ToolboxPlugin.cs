// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugWindow.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Show a debug window that listens to all events
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Toolbox
{
    /// <summary>
    ///     The debug window plugin.
    /// </summary>
    [MapWindowPlugin]
    public class ToolboxPlugin : BasePlugin
    {
        private IAppContext _context;
        private ToolboxGenerator _generator;
        private ToolboxListener _listener;

        public override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            _generator = context.Container.GetInstance<ToolboxGenerator>();
            _listener = context.Container.GetInstance<ToolboxListener>();
        }

        public override void Terminate()
        {
         
        }
    }
}