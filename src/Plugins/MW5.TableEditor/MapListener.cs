using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Helpers;

namespace MW5.Plugins.TableEditor
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly TableEditorPlugin _plugin;

        public MapListener(IAppContext context, TableEditorPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            _context = context;
            _plugin = plugin;

            _plugin.LayerSelected += LayerSelected;
        }

        private void LayerSelected(IMuteLegend legend, LayerEventArgs e)
        {
            var form = _plugin.Form;
            if (form == null)
            {
                return;
            }

            form.CheckAndSaveChanges();

            if (_context.Layers.GetFeatureSet(e.LayerHandle) == null)
            {
                form.Close();
                form.Dispose();
                return;
            }

            var sf = _context.CreateShapefileWrapper();
            if (sf == null)
            {
                MessageBox.Show(form, "Selected layer is not a shapefile");
                return;
            }

            _context.ClearAllSelection();

            form.ShapefileWrapper = sf;
            form.SetDataGrid();
        }
    }
}
