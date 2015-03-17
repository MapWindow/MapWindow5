// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplatePlugin.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The template plugin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MW5.Plugins.TemplatePlugin
{
    #region

    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using MW5.Api.Legend.Abstract;
    using MW5.Api.Legend.Events;
    using MW5.Plugins.Concrete;
    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Mef;
    using MW5.Plugins.TemplatePlugin.Menu;
    using MW5.Plugins.TemplatePlugin.Properties;

    #endregion

    /// <summary>
    ///     The template plugin.
    /// </summary>
    /// <remarks>
    ///     TODO: Investigate how read these PluginExport attributes from the assembly info, preferable in the base plug-in.
    /// </remarks>
    [PluginExport("Template plugin", "Author", "BAE94101-5DBE-43E5-9D55-BC2532A2168C")]
    public class TemplatePlugin : BasePlugin
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
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();
            _mapListener = context.Container.GetInstance<MapListener>();

            // Legend event handler to raise when a layer is selected:
            this.LayerSelected += TemplatePlugin_LayerSelected;

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

        #region Methods

        /// <summary>
        /// The layer selected event handler
        /// </summary>
        /// <param name="legend">
        /// The legend.
        /// </param>
        /// <param name="e">
        /// The layer event arguments
        /// </param>
        private void TemplatePlugin_LayerSelected(IMuteLegend legend, LayerEventArgs e)
        {
            Debug.Print("Layer selected: " + e.LayerHandle);
        }

        #endregion
    }
}