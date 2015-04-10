using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Helpers;
using MW5.Plugins.ShapeEditor.Services;

namespace MW5.Plugins.ShapeEditor.Menu
{
    internal class MenuListener
    {
        private readonly ILayerEditingService _layerService;
        private readonly IGeoprocessingService _geoprocessingService;
        private readonly IAppContext _context;

        public MenuListener(IAppContext context, ShapeEditor plugin, ILayerEditingService layerService, 
                IGeoprocessingService geoprocessingService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (geoprocessingService == null) throw new ArgumentNullException("geoprocessingService");

            _layerService = layerService;
            _geoprocessingService = geoprocessingService;
            _context = context;

            plugin.ItemClicked += Plugin_ItemClicked;
        }

        private void Plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            if (HandleGroupOperation(e.ItemKey))
            {
                _context.View.Update();
                return;
            }

            if (HandleMapCursorChange(e.ItemKey))
            {
                _context.View.Update();
                return;
            }

            switch (e.ItemKey)
            {
                case MenuKeys.CreateLayer:
                    _layerService.CreateLayer();
                    break;
                case MenuKeys.LayerEdit:
                    _layerService.ToggleVectorLayerEditing();
                    break;
                case MenuKeys.Undo:
                    _context.Map.History.Undo();
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    break;
                case MenuKeys.Redo:
                    _context.Map.History.Redo();
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    break;
            }
            _context.View.Update();
        }

        public bool HandleMapCursorChange(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.GeometryCreate:
                    _context.Map.MapCursor = MapCursor.AddShape;
                    return true;
                case MenuKeys.VertexEditor:
                    _context.Map.MapCursor = MapCursor.EditShape;
                    return true;
                case MenuKeys.MoveShapes:
                    _context.Map.MapCursor = MapCursor.MoveShapes;
                    return true;
                case MenuKeys.RotateShapes:
                    _context.Map.MapCursor = MapCursor.RotateShapes;
                    return true;
                case MenuKeys.SplitByPolygon:
                    _context.Map.MapCursor = MapCursor.SplitByPolygon;
                    return true;
                case MenuKeys.EraseByPolygon:
                    _context.Map.MapCursor = MapCursor.EraseByPolygon;
                    return true;
                case MenuKeys.ClipByPolygon:
                    _context.Map.MapCursor = MapCursor.ClipByPolygon;
                    return true;
                case MenuKeys.SplitByPolyline:
                    _context.Map.MapCursor = MapCursor.SplitByPolyline;
                    return true;
            }
            return false;
        }

        public bool HandleGroupOperation(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.MergeShapes:
                    _geoprocessingService.MergeShapes();
                    return true;
                case MenuKeys.Copy:
                    _geoprocessingService.CopyShapes();
                    return true;
                case MenuKeys.Paste:
                    _geoprocessingService.PasteShapes();
                    return true;
                case MenuKeys.Cut:
                    _geoprocessingService.CutShapes();
                    return true;
                case MenuKeys.SplitShapes:
                    _geoprocessingService.ExplodeShapes();
                    return true;
                case MenuKeys.RemoveShapes:
                    _geoprocessingService.RemoveShapes();
                    return true;
            }
            return false;
        }
    }
}
