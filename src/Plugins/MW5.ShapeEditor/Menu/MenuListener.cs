using System;
using MW5.Api.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.ShapeEditor.Menu
{
    internal class MenuListener
    {
        private readonly ILayerEditingService _layerService;
        private readonly IGeoprocessingService _geoprocessingService;
        private readonly IAppContext _context;
        private readonly ShapeEditor _plugin;

        public MenuListener(IAppContext context, ShapeEditor plugin, ILayerEditingService layerService, 
                IGeoprocessingService geoprocessingService)
        {
            _plugin = plugin ?? throw new ArgumentNullException("plugin");
            _layerService = layerService ?? throw new ArgumentNullException("layerService");
            _geoprocessingService = geoprocessingService ?? throw new ArgumentNullException("geoprocessingService");
            _context = context ?? throw new ArgumentNullException("context");

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

            if (HandleSnapSetting(e.ItemKey))
            {
                _context.View.Update();
                return;
            }

            if (HandleLayerKeys(e.ItemKey))
            {
                _context.View.Update();
                return;
            }

            if (HandleUndoRedo(e.ItemKey))
            {
                _context.View.Update();
                return;
            }

            _context.View.Update();
        }

        public bool HandleUndoRedo(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Undo:
                    _context.Map.History.Undo();
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    return true;
                case MenuKeys.Redo:
                    _context.Map.History.Redo();
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    return true;
            }
            return false;
        }

        public bool HandleLayerKeys(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.CreateLayer:
                    _layerService.CreateLayer();
                    return true;
                case MenuKeys.LayerEdit:
                    _layerService.ToggleVectorLayerEditing();
                    return true;
            }
            return false;
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
                case MenuKeys.DeleteSelected:
                case MenuKeys.RemoveShapes:
                    _geoprocessingService.RemoveSelectedShapes(true);
                    return true;
            }
            return false;
        }

        public bool HandleSnapSetting(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.SnapToActiveLayer:
                    _layerService.ToggleSnapToActiveLayer();
                    return true;
                case MenuKeys.SnapToAlLayers:
                    _layerService.ToggleSnapToAllLayers();
                    return true;
                case MenuKeys.SnapToSegments:
                    _layerService.ToggleSnapToSegments();
                    return true;
                case MenuKeys.SnapToVertices:
                    _layerService.ToggleSnapToVertices();
                    return true;
            }
            return false;
        }
    }
}
