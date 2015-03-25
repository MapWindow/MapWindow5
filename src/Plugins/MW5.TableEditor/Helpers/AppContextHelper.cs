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
            var form = context.Container.GetInstance<TableEditorForm>();
            form.Layer = context.Layers.SelectedLayer;
            plugin.Form = form;
            form.Show(context.View.MainForm);
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
