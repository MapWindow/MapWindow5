using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Context;
using MW5.Plugins.ShapeEditor.Menu;

namespace MW5.Plugins.ShapeEditor
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly ContextMenuPresenter _contextMenuPresenter;

        public MapListener(IAppContext context, ShapeEditor plugin, ContextMenuPresenter contextMenuPresenter)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (contextMenuPresenter == null) throw new ArgumentNullException("contextMenuPresenter");

            _context = context;

            _contextMenuPresenter = contextMenuPresenter;

            plugin.ChooseLayer += plugin_ChooseLayer;
            plugin.MouseUp += MapMouseUp;
        }

        private void MapMouseUp(IMuteMap map, MouseEventArgs e)
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

        private  void plugin_ChooseLayer(IMuteMap map, Api.Events.ChooseLayerEventArgs e)
        {
            var layer = map.Layers.Current;
            if (layer != null)
            {
                e.LayerHandle = layer.Handle;
            }
        }
    }
}
