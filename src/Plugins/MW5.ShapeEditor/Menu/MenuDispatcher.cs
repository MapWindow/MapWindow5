using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor.Menu
{
    internal class MenuDispatcher
    {
        private readonly ILayerService _layerService;
        private readonly IAppContext _context;

        public MenuDispatcher(IAppContext context, BasePlugin plugin, ILayerService layerService)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (context == null) throw new ArgumentNullException("context");

            _layerService = layerService;
            _context = context;

            plugin.ItemClicked += Plugin_ItemClicked;
        }

        void Plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
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
            }
        }
    }
}
