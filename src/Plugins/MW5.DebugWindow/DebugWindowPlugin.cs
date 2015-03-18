// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugWindow.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Show a debug window that listens to all events
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MW5.Plugins.DebugWindow
{
    #region

    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using MW5.Plugins.Concrete;
    using MW5.Plugins.DebugWindow.Menu;
    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Mef;

    #endregion

    /// <summary>
    ///     The debug window plugin.
    /// </summary>
    /// <remarks>
    ///     TODO: Investigate how read these PluginExport attributes from the assembly info, preferable in the base plug-in.
    /// </remarks>
    [PluginExport("DebugWindow", "Paul Meems", "F0CDF80F-5F74-48F6-8C8D-75F9B505EEE0")]
    public class DebugWindowPlugin : BasePlugin
    {
        #region Fields

        /// <summary>
        ///     The context of the application, holding the menu, layers, project, etc.
        /// </summary>
        private IAppContext _context;

        /// <summary>
        /// The _file version info.
        /// </summary>
        private FileVersionInfo _fileVersionInfo;

        /// <summary>
        ///     The reference to the map listener class, is used in the constructor
        /// </summary>
        private MapListener _mapListener;

        /// <summary>
        ///     The reference to the menu generator class, is used in the constructor
        /// </summary>
        private MenuGenerator _menuGenerator;

        /// <summary>
        ///     The reference to the menu listener class, is used in the constructor
        /// </summary>
        private MenuListener _menuListener;

        /// <summary>
        ///     The reference to the sample dock user control, is used in the constructor
        /// </summary>
        private DebugWindow _debugWindow;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Short description of the plugin, from AssemblyDescription
        /// </summary>
        /// <remarks>
        ///     TODO: Should be in BasePlugin.
        /// </remarks>
        public override string Description
        {
            get
            {
                return this.ReferenceFile.Comments;
            }
        }

        /// <summary>
        /// Name of the plugin.
        /// </summary>
        /// <remarks>
        ///     TODO: Should be in BasePlugin.
        /// </remarks>
        public virtual string Name
        {
            get
            {
                return this.ReferenceFile.ProductName;
            }
        }

        /// <summary>
        /// Author of the plugin.
        /// </summary>
        /// <remarks>
        ///     TODO: Actually this is the company name, perhaps it is better to use a custom attribute called Author?</remarks>
        ///     TODO: Should be in BasePlugin.
        /// </remarks>
        public virtual string Author
        {
            get
            {
                return this.ReferenceFile.CompanyName;
            }
        }

        /// <summary>
        /// Guid of the assembly.
        /// </summary>
        /// <remarks>
        ///     TODO: Should be in BasePlugin.
        /// </remarks>
        public virtual string Guid
        {
            get
            {
                var attribute = (GuidAttribute)this.ReferenceAssembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
                return attribute.Value;                
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the reference assembly.
        /// </summary>
        /// <remarks>
        ///     TODO: Should be in BasePlugin.
        /// </remarks>
        private Assembly ReferenceAssembly
        {
            get
            {
                return this.GetType().Assembly;
            }
        }

        /// <summary>
        /// Gets the reference file.
        /// </summary>
        /// <remarks>
        ///     TODO: Should be in BasePlugin.
        /// </remarks>
        private FileVersionInfo ReferenceFile
        {
            get
            {
                return _fileVersionInfo
                       ?? (_fileVersionInfo = FileVersionInfo.GetVersionInfo(this.ReferenceAssembly.Location));
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize method, called when the plug-in is loaded
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        public override void Initialize(IAppContext context)
        {
            // Save to local properties:
            _context = context;

            // Set up container for dependency injection:
            CompositionRoot.Compose(context.Container);

            // Will better to preserve state if plugin is unloaded, therefore singleton
            // Because SampleDockWindow is injected in MenuListener and MapListener it should be call before them:
            _debugWindow = context.Container.GetSingleton<DebugWindow>();   

            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();
            _mapListener = context.Container.GetInstance<MapListener>();

            // Event handlers are in the MapListener class:

            // Just to show case:
            Debug.WriteLine("Number of layers loaded" + _context.Layers.Count());
        }

        /// <summary>
        ///     For cleaning activity necessary during unloading of the plug-in
        /// </summary>
        public override void Terminate()
        {
            // menus & toolbars will be cleared automatically
        }

        #endregion
    }
}