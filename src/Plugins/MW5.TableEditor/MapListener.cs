using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Api.Interfaces;
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
            _plugin.SelectionChanged += SelectionChanged;

            // TODO: handle update table join event
        }

        //  /// <summary>
        //  /// Restores join operation
        //  /// </summary>
        //  /// <param name="filename">Filename of the join source to restore</param>
        //  /// <param name="fieldNames">The name of fieds to be included in table</param>
        //  /// <param name="joinOptions">Options specific for particular data source, like separator for csv or worksheet name for Excel</param>
        //  /// <param name="tableToFill">Table to be filled from source and consumed by ocx</param>
        //  private void Project_OnUpdateTableJoin(string filename, string fieldNames, string joinOptions, Table tableToFill)
        //  {
        //    if (this.handleEvents)
        //    {
        //      BOShapeData.Table_OnUpdateJoin(filename, fieldNames, joinOptions, tableToFill);
        //    }
        //  }

        private void SelectionChanged(IMuteMap map, SelectionChangedEventArgs e)
        {
            if (_plugin.Form != null)
            {
                _plugin.Form.SetSelected();
            }
        }

        private void LayerSelected(IMuteLegend legend, LayerEventArgs e)
        {
            var form = _plugin.Form;
            if (form == null)
            {
                return;
            }

            if (e.LayerHandle != -1)
            {
                form.CheckAndSaveChanges();
            }

            if (_context.Layers.GetFeatureSet(e.LayerHandle) == null)
            {
                form.Close();
                _plugin.Form = null;
                return;
                
            }

            _context.ClearAllSelection();

            form.Layer = _context.Map.GetLayer(e.LayerHandle);
        }
    }
}
