using MW5.Plugins.AdvancedSnapping.Services;
using MW5.Plugins.AdvancedSnapping.Context;
using MW5.Plugins.AdvancedSnapping.Listeners;
using MW5.Plugins.AdvancedSnapping.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.ShapeEditor.Context;
using System.Collections.Generic;
using System.Windows;

namespace MW5.Plugins.AdvancedSnapping
{
    [MapWindowPlugin(loadOnStartUp: true, After = new[] { "Shape Editor" })]
    public class AdvancedSnappingPlugin : BasePlugin
    {
        #region private variables
        private IAppContext _context;
        private IAnchorService _anchorService;
        private ISnapRestrictionService _snapRestrictionService;
        #endregion

        #region Properties:
        public bool CanSnapPerpendicular
        {
            get => _anchorService.ReferenceSegment != null;
        }

        public bool CanSnapParallel
        {
            get => _anchorService.ReferenceSegment != null;
        }

        public bool CanSnapBearing
        {
            get => true;
        }

        public bool CanSnapDistance
        {
            get => true;
        }

        public bool HasActiveSnapLines
        {
            get => _snapRestrictionService.HasActiveRestrictions;
        }

        public bool AutoClearSnapLines
        {
            get => _snapRestrictionService.AutoClear;
        }

        #endregion

        #region Initialization

        public override void Initialize(IAppContext context)
        {
            _context = context;

            WPFWorkArounds();

            IApplicationContainer container = context.Container;
            container.GetInstance<ContextMenuExtender>();
            container.GetInstance<ContextMenuView>();
            container.GetInstance<MapListener>();
            _anchorService = container.GetSingleton<IAnchorService>();
            _snapRestrictionService = container.GetSingleton<ISnapRestrictionService>();
        }

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        internal void WPFWorkArounds()
        {
            // Makes sure we have a WPF application, windows forms app does not initialize this for us:
            WindowExtensions.MainWindowHandle = _context.View.MainForm.Handle;

            WindowExtensions.EnsureApplicationResources();

            if (null == Application.Current)
            {
                var app = new Application();
                System.Windows.Forms.Application.EnableVisualStyles();
            }
        }

        #endregion

        #region Plugin settings

        public override void SetSettings(IDictionary<string, string> settings)
        {
            base.SetSettings(settings);
            if (settings.TryGetValue("AutoClearSnapLines", out string autoClearSnapLines))
                _snapRestrictionService.AutoClear = bool.Parse(autoClearSnapLines);
        }

        public override IDictionary<string, string> GetSettings()
        {
            var settings = base.GetSettings();
            settings["AutoClearSnapLines"] = AutoClearSnapLines.ToString();
            return settings;
        }

        #endregion

    }
}
