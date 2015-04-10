using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Services;

namespace MW5.Plugins.ShapeEditor
{
    public class ProjectListener
    {
        private readonly IAppContext _context;
        private readonly ILayerEditingService _layerService;

        public ProjectListener(IAppContext context, ShapeEditor plugin, ILayerEditingService layerService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");

            _context = context;
            _layerService = layerService;
            
            plugin.ProjectClosing += plugin_ProjectClosing;
            plugin.BeforeRemoveLayer += plugin_BeforeRemoveLayer;
        }

        private void plugin_BeforeRemoveLayer(object sender, LayerRemoveEventArgs e)
        {
            if (_context.Map.GeometryEditor.LayerHandle == e.LayerHandle)
            {
                if (!_context.Map.GeometryEditor.SaveChanges())
                {
                    e.Cancel = true;
                    return;
                }
            }

            var layer = _context.Map.Layers.ItemByHandle(e.LayerHandle);
            if (layer != null && layer.FeatureSet != null && layer.FeatureSet.InteractiveEditing)
            {
                if (!_layerService.SaveLayerChanges(layer.Handle))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void plugin_ProjectClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_context.Map.GeometryEditor.SaveChanges())
            {
                e.Cancel = true;
                return;
            }
            
            var layers = _context.Map.Layers;

            foreach (var layer in layers)
            {
                var fs = layer.FeatureSet;
                if (fs != null && fs.InteractiveEditing)
                {
                    if (!_layerService.SaveLayerChanges(layer.Handle))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
    }
}
