using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Helpers;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor.Menu
{
    internal class MenuDispatcher
    {
        private readonly ILayerService _layerService;
        private readonly GeoprocessingService _geoprocessingService;
        private readonly IAppContext _context;

        public MenuDispatcher(IAppContext context, BasePlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");

            _layerService = context.Container.Resolve<ILayerService>();
            _geoprocessingService = context.Container.GetSingleton<GeoprocessingService>();
            _context = context;

            plugin.ItemClicked += Plugin_ItemClicked;
        }

        private void Plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            if (HandleGroupOperation(e.ItemKey))
            {
                return;
            }

            switch (e.ItemKey)
            {
                case MenuKeys.LayerCreate:
                    _layerService.CreateLayer();
                    break;
                case MenuKeys.LayerEdit:
                    _layerService.ToggleVectorLayerEditing();
                    break;
                case MenuKeys.GeometryCreate:
                    _context.Map.MapCursor = MapCursor.AddShape;
                    break;
                case MenuKeys.VertexEditor:
                    _context.Map.MapCursor = MapCursor.EditShape;
                    break;
                case MenuKeys.MoveShapes:
                    break;
                case MenuKeys.RotateShapes:
                    break;
                case MenuKeys.Undo:
                    break;
                case MenuKeys.Redo:
                    break;
            }
        }

        public bool HandleGroupOperation(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.MergeShapes:
                    _geoprocessingService.MergeShapes();
                    return true;
                //case MenuKeys.Copy:
                //    OperationHelper.CopyShapes();
                //    return true;
                //case MenuKeys.Paste:
                //    OperationHelper.PasteShapes();
                //    return true;
                //case MenuKeys.Cut:
                //    OperationHelper.CutShapes();
                //    return true;
                //case MenuKeys.SplitShapes:
                //    OperationHelper.ExplodeShapes();
                //    return true;
                //case EditorCommand.RemoveShapes:
                //    GeoprocessingService.RemoveShapes();
                //    return true;
            }
            return false;
        }
    }
}
