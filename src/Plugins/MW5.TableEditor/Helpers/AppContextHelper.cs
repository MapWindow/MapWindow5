using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Forms;

namespace MW5.Plugins.TableEditor.Helpers
{
    public static class AppContextHelper
    {
        internal static void ShowEditorForm(this IAppContext context, TableEditorPlugin plugin)
        {
            var sf = CreateShapefileWrapper(context);
            var form = new TableEditorForm(sf, new AppContextWrapper(context));
            form.InitForm();
            plugin.Form = form;
            form.Show(context.View.MainForm);
        }

        internal static ShapefileWrapper CreateShapefileWrapper(this IAppContext context)
        {
            var layer = context.Layers.SelectedLayer;
            if (layer == null)
            {
                return null;
            }

            ShapefileWrapper boShapeFile = null;

            var sf = context.Layers.SelectedLayer.FeatureSet.InternalObject as Shapefile;
            if (sf != null)
            {
                boShapeFile = new ShapefileWrapper
                {
                    Shapefile = sf,
                    ShapefileName = layer.Name
                };
            }
            return boShapeFile;
        }

        /// <summary>
        /// Clears selection from all layers.
        /// </summary>
        internal static void ClearAllSelection(this IAppContext context)
        {
            foreach (var layer in context.Layers)
            {
                var fs = layer.FeatureSet;
                if (fs != null)
                {
                    fs.ClearSelection();
                }
            }
        }
    }
}
