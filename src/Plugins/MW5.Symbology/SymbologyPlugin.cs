using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Menu;
using MW5.Plugins.Symbology.Services;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology
{
    [PluginExport()]
    public class SymbologyPlugin : BasePlugin
    {
        private static IAppContext _context;
        private LegendListener _legendListener;
        private MenuService _menuService;
        private LabelMover _labelMover;
        private SymbologyMetadataService _metadataService;

        internal static IMessageService Msg
        {
            get { return _context.Container.GetSingleton<IMessageService>(); }
        }

        internal static SymbologyMetadata Metadata(int layerHandle)
        {
            var service = _context.Container.Resolve<SymbologyMetadataService>();
            return service.Get(layerHandle);
        }

        internal static void AttachMetadata(int layerHandle)
        {
            var service = _context.Container.Resolve<SymbologyMetadataService>();
            service.Save(layerHandle, new SymbologyMetadata());
        }

        public override void RegisterServices(IApplicationContainer container)
        {
            EnumHelper.RegisterConverter(new SymbologyTypeCoverter());

            ColorSchemeProvider.Load();
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            _metadataService = context.Container.GetSingleton<SymbologyMetadataService>();
            _labelMover = context.Container.GetSingleton<LabelMover>();
            _legendListener = context.Container.GetInstance<LegendListener>();
            _menuService = context.Container.GetInstance<MenuService>();
        }

        public override void Terminate()
        {
            
        }
    }
}
