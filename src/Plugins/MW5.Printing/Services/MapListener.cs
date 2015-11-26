using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Views;
using MW5.Plugins.Services;

namespace MW5.Plugins.Printing.Services
{
    internal class MapListener
    {
        private readonly IAppContext _context;
        private readonly PrintingPlugin _plugin;

        public MapListener(IAppContext context, PrintingPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            _context = context;
            _plugin = plugin;

            plugin.SelectBoxFinal += OnSelectBoxFinal;
        }

        private void OnSelectBoxFinal(Api.Interfaces.IMuteMap map, Api.Events.SelectBoxFinalEventArgs e)
        {
            if (e.ClientId == _plugin.Identity.Guid)
            {
                int layerHandle = _context.Map.DisplaySelection(e.ProjectedBounds);

                Application.DoEvents();

                var model = new TemplateModel(e.ProjectedBounds, _plugin.PrinterSettings);
                if (_context.Container.Run<TemplatePresenter, TemplateModel>(model))
                {
                    // remove selection before we are drawing the layout
                    var oldGrabProjectionFromData = _context.Map.GrabProjectionFromData;
                    _context.Map.GrabProjectionFromData = false;

                    _context.Map.Layers.Remove(layerHandle);

                    _context.Map.GrabProjectionFromData = oldGrabProjectionFromData;

                    _context.Container.Run<LayoutPresenter, TemplateModel>(model);
                }
                else
                {
                    _context.Map.Layers.Remove(layerHandle);
                }

                _context.Map.Redraw();
            }
        }
    }
}
