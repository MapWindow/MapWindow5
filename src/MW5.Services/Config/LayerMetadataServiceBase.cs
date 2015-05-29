using System;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Services.Config
{
    public abstract class LayerMetadataServiceBase<T> where T: LayerMetadataBase, new()
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
                var o = layer.GetCustomObject<T>(_plugin.Identity.Guid);
                if (o != null)
                {
                    return o;
                }
            }

            var metadata = new T();
            Save(layerHandle, metadata);

            return metadata;
        }

        public void Save(int layerHandle, T settings)
        {
            var layer = _context.Legend.Layers.ItemByHandle(layerHandle);
            if (layer != null)
            {
                layer.SetCustomObject(settings, _plugin.Identity.Guid);
            }
        }
    }
}
