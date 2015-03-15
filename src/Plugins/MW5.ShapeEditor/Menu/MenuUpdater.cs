using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Abstract;
using MW5.Plugins.ShapeEditor.Properties;

namespace MW5.Plugins.ShapeEditor.Menu
{
    public class MenuUpdater
    {
        private readonly IAppContext _context;
        private readonly BasePlugin _plugin;
        private readonly IGeoprocessingService _geoprocessingService;

        public MenuUpdater(IAppContext context, ShapeEditor plugin, IGeoprocessingService geoprocessingService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            
            _context = context;
            _plugin = plugin;
            _geoprocessingService = geoprocessingService;

            _plugin.ViewUpdating += OnViewUpdating;
            _plugin.MapCursorChanged += OnMapCursorChanged;
            _plugin.HistoryChanged += OnViewUpdating;
        }

        private void OnMapCursorChanged(IMuteMap sender, EventArgs e)
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
            
            bool polygonCursor = map.MapCursor ==  Api.MapCursor.ClipByPolygon || 
                                 map.MapCursor == Api.MapCursor.SplitByPolygon || 
                                 map.MapCursor == Api.MapCursor.EraseByPolygon;
            toolbars.FindItem(MenuKeys.PolygonOverlayDropDown).Checked = polygonCursor;
        }

        private void OnViewUpdating(object sender, EventArgs e)
        {
            var bars = _context.Toolbars;

            // first disable all items
            var items = bars.ItemsForPlugin(_plugin.Identity);
            foreach (var item in items)
            {
                item.Enabled = false;
            }

            IFeatureSet fs = null;
            var layer = _context.Map.Layers.SelectedLayer;
            if (layer != null)
            {
                fs = layer.FeatureSet;
            }

            string text = string.Format("{0}\\{1}", _context.Map.History.UndoCount, _context.Map.History.TotalLength);
            _context.Toolbars.FindItem(MenuKeys.HistoryLength).Text = text;

            bool editing = fs != null && fs.InteractiveEditing;

            var editLayerItem = bars.FindItem(MenuKeys.LayerEdit);
            editLayerItem.Enabled = fs != null;
            editLayerItem.Icon = new MenuIcon(editing ? Resources.icon_layer_save : Resources.icon_layer_edit);
            editLayerItem.Text = editing ? "Save Changes" : "Edit Layer";

            if (editing)
            {
                bars.FindItem(MenuKeys.VertexEditor).Enabled = true;
                bars.FindItem(MenuKeys.GeometryCreate).Enabled = true;
                bars.FindItem(MenuKeys.SplitByPolygon).Enabled = true;
                bars.FindItem(MenuKeys.SplitByPolyline).Enabled = true;
                bars.FindItem(MenuKeys.EraseByPolygon).Enabled = true;
                bars.FindItem(MenuKeys.ClipByPolygon).Enabled = true;
                bars.FindItem(MenuKeys.PolygonOverlayDropDown).Enabled = true;
                bars.FindItem(MenuKeys.HistoryLength).Enabled = true;
                
                int selectedCount = fs.NumSelected;
                bars.FindItem(MenuKeys.MergeShapes).Enabled = selectedCount > 1;
                bars.FindItem(MenuKeys.SplitShapes).Enabled = selectedCount > 0;
                bars.FindItem(MenuKeys.MoveShapes).Enabled = selectedCount > 0;
                bars.FindItem(MenuKeys.RotateShapes).Enabled = selectedCount > 0;
            }

            var list = new[] { MenuKeys.Copy, MenuKeys.Paste, MenuKeys.Cut, MenuKeys.Undo, MenuKeys.Redo };
            foreach (var item in list)
            {
                var menuItem = bars.FindItem(item);
                menuItem.Enabled = GetEnabled(item);
            }
        }

        internal bool GetEnabled(string itemKey)
        {
            var map = _context.Map;
            var layer = _context.Map.Layers.SelectedLayer;
            if (layer == null)
            {
                return false;
            }
            
            var fs = layer.FeatureSet;
            if (fs == null)
            {
                return false;
            }

            switch (itemKey)
            {
                case MenuKeys.Undo:
                    return map.History.UndoCount > 0;
                case MenuKeys.Redo:
                    return map.History.RedoCount > 0;
                case MenuKeys.Copy:
                    return fs.NumSelected > 0;
                case MenuKeys.Cut:
                    return fs.NumSelected > 0 && fs.InteractiveEditing;
                case MenuKeys.Paste:
                    return !_geoprocessingService.BufferIsEmpty && fs.InteractiveEditing;
            }
            return false;
        }
    }
}
