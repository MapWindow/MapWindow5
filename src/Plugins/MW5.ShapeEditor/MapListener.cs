using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Context;
using MW5.Plugins.ShapeEditor.Views;

namespace MW5.Plugins.ShapeEditor
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly ContextMenuPresenter _contextMenuPresenter;
        private readonly IBroadcasterService _broadcaster;

        public MapListener(IAppContext context, ShapeEditor plugin, ContextMenuPresenter contextMenuPresenter,
                           IBroadcasterService broadcaster)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (contextMenuPresenter == null) throw new ArgumentNullException("contextMenuPresenter");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");

            _context = context;

            _contextMenuPresenter = contextMenuPresenter;
            _broadcaster = broadcaster;

            plugin.ChooseLayer += OnChooseLayer;
            plugin.MouseUp += OnMapMouseUp;
            plugin.BeforeDeleteShape += OnBeforeDeleteShape;
            plugin.AfterShapeEdit += OnAfterShapeEdit;
            plugin.ShapeValidationFailed += OnShapeValidationFailed;
        }

        private void OnBeforeDeleteShape(IMuteMap map, BeforeDeleteShapeEventArgs e)
        {
            if (e.Silent || e.Cancel || (e.Target == DeleteTarget.Vertex && Control.ModifierKeys.HasFlag(Keys.Control)))
            {
                // don't bother user with prompt
                return;
            }

            string s = string.Empty;
            switch (e.Target)
            {
                case DeleteTarget.Shape: s = "shape";
                    break;
                case DeleteTarget.Part: s = "part";
                    break;
                case DeleteTarget.Vertex: s = "vertex";
                    break;
            }

            s = string.Format("Do you want to delete {0}?", s);
            e.Cancel = !MessageService.Current.Ask(s);
        }

        private void OnMapMouseUp(IMuteMap map, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var parent = map as Control;
            if (parent == null)
            {
                return;
            }

            switch (_context.Map.MapCursor)
            {
                case MapCursor.RotateShapes:
                case MapCursor.MoveShapes:
                case MapCursor.Selection:
                {
                    var menu = _contextMenuPresenter.SelectionMenu;
                    menu.Show(parent, e.X, e.Y);
                    break;
                }
                case MapCursor.EditShape:
                case MapCursor.AddShape:
                case MapCursor.ClipByPolygon:
                case MapCursor.EraseByPolygon:
                case MapCursor.SplitByPolygon:
                case MapCursor.SplitByPolyline:
                case MapCursor.SelectByPolygon:
                {
                    var menu = _contextMenuPresenter.VertexMenu;
                    menu.Show(parent, e.X, e.Y);
                    break;
                }
            }
        }

        private void OnChooseLayer(IMuteMap map, ChooseLayerEventArgs e)
        {
            var layer = map.Layers.Current;
            if (layer != null)
            {
                e.LayerHandle = layer.Handle;
            }
        }

        private void OnAfterShapeEdit(IMuteMap map, AfterShapeEditEventArgs e)
        {
            if (e.Operation == UndoOperation.AddShape && AppConfig.Instance.ShapeEditorShowAttributeDialog)
            {
                var fs = _context.Map.GetFeatureSet(e.LayerHandle);
                if (fs != null)
                {
                    var layer = _context.Layers.ItemByHandle(e.LayerHandle);
                    var model = new AttributeViewModel(layer, e.ShapeIndex);

                    if (_context.Container.Run<AttributePresenter, AttributeViewModel>(model))
                    {
                        
                    }
                }
            }

            if (e.Operation == UndoOperation.AddShape)
            {
                var fs = _context.Map.GetFeatureSet(e.LayerHandle);
                _broadcaster.BroadcastEvent(p => p.LayerFeatureCountChanged_, fs, new LayerEventArgs(e.LayerHandle));
            }

            // to show the number of modified features
            _context.View.Update();
        }

        private void OnShapeValidationFailed(IMuteMap map, ShapeValidationFailedEventArgs e)
        {
            MessageService.Current.Warn("Validation failed: " + e.ErrorMessage);
        }
    }
}
