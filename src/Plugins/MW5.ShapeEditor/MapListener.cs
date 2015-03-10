using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Menu;

namespace MW5.Plugins.ShapeEditor
{
    public class MapListener
    {
        private readonly IAppContext _context;

        public MapListener(BasePlugin plugin, IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            plugin.ExtentsChanged += plugin_ExtentsChanged;
            plugin.MapCursorChanged += plugin_MapCursorChanged;
            plugin.ChooseLayer += plugin_ChooseLayer;
            plugin.HistoryChanged += plugin_HistoryChanged;
        }

        private void plugin_HistoryChanged(IMuteMap map, EventArgs e)
        {
            string text = string.Format("{0}\\{1}", map.History.UndoCount, map.History.TotalLength);
            _context.Toolbars.FindItem(MenuKeys.HistoryLength).Text = text;
        }

        private  void plugin_ChooseLayer(IMuteMap map, Api.Events.ChooseLayerEventArgs e)
        {
            var layer = map.Layers.SelectedLayer;
            if (layer != null)
            {
                e.LayerHandle = layer.Handle;
            }
        }

        private void plugin_MapCursorChanged(IMuteMap sender, EventArgs e)
        {
            var toolbars = _context.Toolbars;
            var map = _context.Map;

            toolbars.FindItem(MenuKeys.GeometryCreate).Checked = map.MapCursor == Api.MapCursor.AddShape;
            toolbars.FindItem(MenuKeys.VertexEditor).Checked = map.MapCursor == Api.MapCursor.EditShape;
            toolbars.FindItem(MenuKeys.MoveShapes).Checked = map.MapCursor == Api.MapCursor.MoveShapes;
            toolbars.FindItem(MenuKeys.RotateShapes).Checked = map.MapCursor == Api.MapCursor.RotateShapes;
            toolbars.FindItem(MenuKeys.SplitByPolyline).Checked = map.MapCursor == Api.MapCursor.SplitByPolyline;
            toolbars.FindItem(MenuKeys.SplitByPolygon).Checked = map.MapCursor == Api.MapCursor.SplitByPolygon;
            toolbars.FindItem(MenuKeys.EraseByPolygon).Checked = map.MapCursor == Api.MapCursor.EraseByPolygon;
            toolbars.FindItem(MenuKeys.ClipByPolygon).Checked = map.MapCursor == Api.MapCursor.ClipByPolygon;
        }

        private void plugin_ExtentsChanged(IMuteMap sender, EventArgs e)
        {
            
        }
    }
}
