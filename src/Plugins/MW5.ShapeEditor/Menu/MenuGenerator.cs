using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api;
using MW5.Mvp;
using MW5.Mvp.Menu;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Properties;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor.Menu
{
    public class MenuGenerator
    {
        private const string SHAPE_EDITOR_TOOLBAR = "Shape editor";    // perhaps simply use plugin name as a default
        
        private readonly BasePlugin _plugin;
        private readonly ILayerService _layerService;
        private readonly IAppContext _context;

        public MenuGenerator(IAppContext context, BasePlugin plugin, ILayerService layerService)
        {
            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }
            if (layerService == null)
            {
                throw new ArgumentNullException("layerService");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _plugin = plugin;
            _layerService = layerService;
            _context = context;

            _plugin.ItemClicked += Plugin_ItemClicked;

            InitToolbar();
        }

        private void InitToolbar()
        {
            var bar = _context.Toolbars.Add(SHAPE_EDITOR_TOOLBAR);
            
            var btn = bar.Items.AddButton("Edit layer", MenuKeys.LayerEdit, _plugin.Identity);
            btn.Icon = new MenuIcon(Resources.layer_edit);

            btn = bar.Items.AddButton("Create new layer", MenuKeys.LayerCreate, _plugin.Identity);
            btn.Icon = new MenuIcon(Resources.layer_create);

            btn = bar.Items.AddButton("Add geometry", MenuKeys.GeometryCreate, _plugin.Identity);
            btn.Icon = new MenuIcon(Resources.geometry_create);

            btn = bar.Items.AddButton("Vertex editor", MenuKeys.VertexEditor, _plugin.Identity);
            btn.Icon = new MenuIcon(Resources.vertex_editor);
        }

        private void InitMenu()
        {
            
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
