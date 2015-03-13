using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor
{
    public class ProjectListener
    {
        private readonly IAppContext _context;
        private readonly ILayerService _layerService;

        public ProjectListener(IAppContext context,  BasePlugin plugin)
        {
            _context = context;
            _layerService = context.Container.Resolve<ILayerService>();

            if (context == null) throw new ArgumentNullException("context");
            if (_layerService == null) throw new ArgumentNullException("layerService");
            
            plugin.ProjectClosing += plugin_ProjectClosing;
        }

        private void plugin_ProjectClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
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
