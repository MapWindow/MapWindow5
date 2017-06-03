using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

namespace MW5.Plugins.ShapeEditor.Context
{
    public class ContextMenuPresenter : CommandDispatcher<ContextMenuView, EditorCommand>
    {
        private readonly IAppContext _context;
        private readonly ILayerService _layerService;
        private readonly IGeoprocessingService _geoService;

        public ContextMenuPresenter(IAppContext context, ILayerService layerService, 
                        IGeoprocessingService geoService, ContextMenuView view)
            :base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (geoService == null) throw new ArgumentNullException("geoService");
            _context = context;
            _layerService = layerService;
            _geoService = geoService;
        }

        public ContextMenuStrip DigitizingMenu
        {
            get { return View.DigitizingMenu; }
        }

        public ContextMenuStrip SelectionMenu
        {
            get { return View.SelectionMenu; }
        }

        public ContextMenuStrip VertexMenu
        {
            get { return View.VertexMenu; }
        }

        public override void RunCommand(EditorCommand command)
        {
            if (HandleGroupOperation(command)) return;

            if (HandleChangeTool(command)) return;

            if (HandleVertexEditor(command)) return;

            if (HandleSnappingAndHighlighting(command)) return;

            var map = _context.Map;
            switch (command)
            {
                case EditorCommand.Undo:
                case EditorCommand.UndoPoint:
                    map.Undo();
                    map.Redraw(RedrawType.SkipDataLayers);
                    break;
                case EditorCommand.Redo:
                    map.History.Redo();
                    map.Redraw(RedrawType.SkipDataLayers);
                    break;
                case EditorCommand.ClearSelection:
                    _layerService.ClearSelection();
                    break;
            }

            _context.View.Update();
        }

        public bool HandleSnappingAndHighlighting(EditorCommand command)
        {
            var editor = _context.Map.GeometryEditor;

            switch (command)
            {
                case EditorCommand.SnappingNone:
                    editor.SnapBehavior = LayerSelectionMode.NoLayer;
                    break;
                case EditorCommand.SnappingCurrent:
                    editor.SnapBehavior = LayerSelectionMode.ActiveLayer;
                    break;
                case EditorCommand.SnappingAll:
                    editor.SnapBehavior = LayerSelectionMode.AllLayers;
                    break;
                case EditorCommand.HighlightNone:
                    editor.HighlightVertices = LayerSelectionMode.NoLayer;
                    break;
                case EditorCommand.HighlightCurrent:
                    editor.HighlightVertices = LayerSelectionMode.ActiveLayer;
                    break;
                case EditorCommand.HighlightAll:
                    editor.HighlightVertices = LayerSelectionMode.AllLayers;
                    break;
            }
            return false;
        }

        public bool HandleVertexEditor(EditorCommand command)
        {
            var editor = _context.Map.GeometryEditor;

            switch (command)
            {
                case EditorCommand.ClearEditor:
                case EditorCommand.CancelShape:
                    editor.Clear();
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    return true;
                case EditorCommand.SaveShape:
                case EditorCommand.FinishShape:
                    editor.SaveChanges();
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    return true;
                case EditorCommand.AddPart:
                    editor.StartOverlay(EditorOverlay.AddPart);
                    return true;
                case EditorCommand.RemovePart:
                    editor.StartOverlay(EditorOverlay.RemovePart);
                    return true;
                case EditorCommand.VertexEditor:
                    editor.EditorBehavior = EditorBehavior.VertexEditor;
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    return true;
                case EditorCommand.PartEditor:
                    editor.EditorBehavior = EditorBehavior.PartEditor;
                    _context.Map.Redraw(RedrawType.SkipDataLayers);
                    return true;
            }
            return false;
        }

        public bool HandleChangeTool(EditorCommand command)
        {
            var map = _context.Map;

            switch (command)
            {
                case EditorCommand.SelectByRectangle:
                    map.MapCursor = MapCursor.Selection;
                    return true;
                case EditorCommand.SplitByPolygon:
                     map.MapCursor = MapCursor.SplitByPolygon;
                    return true;
                case EditorCommand.EraseByPolygon:
                     map.MapCursor = MapCursor.EraseByPolygon;
                    return true;
                case EditorCommand.ClipByPolygon:
                     map.MapCursor = MapCursor.ClipByPolygon;
                    return true;
                case EditorCommand.SplitByPolyline:
                     map.MapCursor = MapCursor.SplitByPolyline;
                    return true;
                case EditorCommand.RotateShapes:
                     map.MapCursor = MapCursor.RotateShapes;
                    return true;
                case EditorCommand.MoveShapes:
                     map.MapCursor = MapCursor.MoveShapes;
                    return true;
                case EditorCommand.AddShape:
                     map.MapCursor = MapCursor.AddShape;
                    return true;
                case EditorCommand.EditShape:
                     map.MapCursor = MapCursor.EditShape;
                    return true;
            }
            return false;
        }

        public bool HandleGroupOperation(EditorCommand command)
        {
            switch (command)
            {
                case EditorCommand.Copy:
                    _geoService.CopyShapes();
                    return true;
                case EditorCommand.Paste:
                    _geoService.PasteShapes();
                    return true;
                case EditorCommand.Cut:
                    _geoService.CutShapes();
                    return true;
                case EditorCommand.SplitShapes:
                    _geoService.ExplodeShapes();
                    return true;
                case EditorCommand.MergeShapes:
                    _geoService.MergeShapes();
                    return true;
                case EditorCommand.RemoveShapes:
                    _geoService.RemoveSelectedShapes(true);
                    return true;
            }
            return false;
        }
    }
}
