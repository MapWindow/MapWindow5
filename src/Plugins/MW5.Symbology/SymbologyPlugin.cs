using System;
using System.Collections.Generic;
using MW5.Api.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Menu;
using MW5.Plugins.Symbology.Model;
using MW5.Plugins.Symbology.Services;
using MW5.Services.Config;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology
{
    [MapWindowPlugin()]
    public class SymbologyPlugin : BasePlugin
    {
        private static IAppContext _context;
        private LegendListener _legendListener;
        private MenuService _menuService;
        private LabelMover _labelMover;
        private SymbologyMetadataService _metadataService;

        internal static SymbologyMetadata GetMetadata(int layerHandle)
        {
            var service = _context.Container.Resolve<SymbologyMetadataService>();
            var metadata = service.Get(layerHandle);

            if (!metadata.Initialized)
            {
                var layer = _context.Layers.ItemByHandle(layerHandle);
                if (layer != null && layer.FeatureSet != null)
                {
                    metadata.ShowLayerPreview = layer.FeatureSet.NumFeatures < 5000;
                    metadata.Initialized = true;
                }
            }

            return metadata;
        }

        internal static void SaveMetadata(int layerHandle, SymbologyMetadata metadata)
        {
            var service = _context.Container.Resolve<SymbologyMetadataService>();
            service.Save(layerHandle, new SymbologyMetadata());
        }

        public override IEnumerable<IConfigPage> ConfigPages
        {
            get { yield return _context.Container.GetSingleton<SymbologyConfigPage>(); }
        }

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);

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
            _menuService.OnPluginUnloaded();
        }
    }
}
