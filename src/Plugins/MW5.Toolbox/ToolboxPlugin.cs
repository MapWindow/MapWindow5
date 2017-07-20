// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolboxPlugin.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Load the toolbox
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Tools.Helpers;

namespace MW5.Plugins.Toolbox
{
    /// <summary>
    ///     The debug window plugin.
    /// </summary>
    [MapWindowPlugin(loadOnStartUp: true)]
    public class ToolboxPlugin : BasePlugin
    {
        private IAppContext _context;
        private ToolboxGenerator _generator;

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            _generator = context.Container.GetInstance<ToolboxGenerator>();

            _context.Toolbox.AddTools(GetType().Assembly.GetTools());
        }
    }
}