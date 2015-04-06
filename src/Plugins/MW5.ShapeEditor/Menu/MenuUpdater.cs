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
using MW5.UI.Menu;

namespace MW5.Plugins.ShapeEditor.Menu
{
    public class MenuUpdater: MenuServiceBase
    {
        private readonly ShapeEditor _plugin;
        private readonly IGeoprocessingService _geoprocessingService;

        public MenuUpdater(IAppContext context, ShapeEditor plugin, IGeoprocessingService geoprocessingService):
            base(context, plugin.Identity)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _plugin = plugin;
            _geoprocessingService = geoprocessingService;

            plugin.ViewUpdating += OnViewUpdating;
            plugin.MapCursorChanged += OnMapCursorChanged;
            plugin.HistoryChanged += OnViewUpdating;
        }

        private void OnMapCursorChanged(IMuteMap sender, EventArgs e)
        {
            var map = _context.Map;

            FindToolbarItem(MenuKeys.GeometryCreate).Checked = map.MapCursor == Api.MapCursor.AddShape;
            FindToolbarItem(MenuKeys.VertexEditor).Checked = map.MapCursor == Api.MapCursor.EditShape;
            FindToolbarItem(MenuKeys.MoveShapes).Checked = map.MapCursor == Api.MapCursor.MoveShapes;
            FindToolbarItem(MenuKeys.RotateShapes).Checked = map.MapCursor == Api.MapCursor.RotateShapes;
            FindToolbarItem(MenuKeys.SplitByPolyline).Checked = map.MapCursor == Api.MapCursor.SplitByPolyline;
            FindToolbarItem(MenuKeys.SplitByPolygon).Checked = map.MapCursor == Api.MapCursor.SplitByPolygon;
            FindToolbarItem(MenuKeys.EraseByPolygon).Checked = map.MapCursor == Api.MapCursor.EraseByPolygon;
            FindToolbarItem(MenuKeys.ClipByPolygon).Checked = map.MapCursor == Api.MapCursor.ClipByPolygon;
            
            bool polygonCursor = map.MapCursor ==  Api.MapCursor.ClipByPolygon || 
                                 map.MapCursor == Api.MapCursor.SplitByPolygon || 
                                 map.MapCursor == Api.MapCursor.EraseByPolygon;
            FindToolbarItem(MenuKeys.PolygonOverlayDropDown).Checked = polygonCursor;
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
            var layer = _context.Map.Layers.Current;
            if (layer != null)
            {
                fs = layer.FeatureSet;
            }

            var text = string.Format("{0}\\{1}", _context.Map.History.UndoCount, _context.Map.History.TotalLength);
            FindToolbarItem(MenuKeys.HistoryLength).Text = text;

            bool editing = fs != null && fs.InteractiveEditing;

            var editLayerItem =FindToolbarItem(MenuKeys.LayerEdit);
            editLayerItem.Enabled = fs != null;
            editLayerItem.Icon = new MenuIcon(editing ? Resources.icon_layer_save : Resources.icon_layer_edit);
            editLayerItem.Text = editing ? "Save Changes" : "Edit Layer";

            if (editing)
            {
               FindToolbarItem(MenuKeys.VertexEditor).Enabled = true;
               FindToolbarItem(MenuKeys.GeometryCreate).Enabled = true;
               FindToolbarItem(MenuKeys.SplitByPolygon).Enabled = true;
               FindToolbarItem(MenuKeys.SplitByPolyline).Enabled = true;
               FindToolbarItem(MenuKeys.EraseByPolygon).Enabled = true;
               FindToolbarItem(MenuKeys.ClipByPolygon).Enabled = true;
               FindToolbarItem(MenuKeys.PolygonOverlayDropDown).Enabled = true;
               FindToolbarItem(MenuKeys.HistoryLength).Enabled = true;
                
                int selectedCount = fs.NumSelected;
               FindToolbarItem(MenuKeys.MergeShapes).Enabled = selectedCount > 1;
               FindToolbarItem(MenuKeys.SplitShapes).Enabled = selectedCount > 0;
               FindToolbarItem(MenuKeys.MoveShapes).Enabled = selectedCount > 0;
               FindToolbarItem(MenuKeys.RotateShapes).Enabled = selectedCount > 0;
            }

            var list = new[] { MenuKeys.Copy, MenuKeys.Paste, MenuKeys.Cut, MenuKeys.Undo, MenuKeys.Redo };
            foreach (var item in list)
            {
                var menuItem = FindToolbarItem(item);
                menuItem.Enabled = GetEnabled(item);
            }
        }

        internal bool GetEnabled(string itemKey)
        {
            var map = _context.Map;
            var layer = _context.Map.Layers.Current;
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
