using System;
using MW5.Api.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Services.Config
{
    public abstract class LayerMetadataServiceBase<T> where T: LayerMetadataBase
    {
        private readonly BasePlugin _plugin;
        private readonly IAppContext _context;

        protected LayerMetadataServiceBase(IAppContext context, BasePlugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (context == null) throw new ArgumentNullException("context");
            _plugin = plugin;
            _context = context;
        }

        public T Get(int layerHandle)
        {
            var layer = _context.Legend.Layers.ItemByHandle(layerHandle);
            if (layer != null)
            {
                return layer.GetCustomObject<T>(_plugin.Identity);
            }
            return null;
        }

        public void Save(int layerHandle, T settings)
        {
            var layer = _context.Legend.Layers.ItemByHandle(layerHandle);
            if (layer != null)
            {
                layer.SetCustomObject(settings, _plugin.Identity);
            }
        }
    }
}
