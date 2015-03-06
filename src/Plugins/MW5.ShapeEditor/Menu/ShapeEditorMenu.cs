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
    // TODO: add GetToolbarNames function
    internal class ShapeEditorMenu : PluginMenuBase<ShapeEditorCommand>
    {
        private readonly ILayerService _layerService;
        private const string PLUGIN_TOOLBAR_NAME = "Shape Editor";

        public ShapeEditorMenu(IAppContext context, ShapeEditor plugin, ILayerService layerService): base(context)
        {
            if (layerService == null)
            {
                throw new ArgumentNullException("layerService");
            }
            _layerService = layerService;

            AddToolbar(PLUGIN_TOOLBAR_NAME, plugin);

            // TODO: provide way to add submenus
            AddMenu(PLUGIN_TOOLBAR_NAME, plugin);
        }

        public override IEnumerable<MenuItemData<ShapeEditorCommand>> GetMenuItems(string toolBarName, 
            Func<ShapeEditorCommand, Bitmap, string, MenuItemData<ShapeEditorCommand>> createItem)
        {
            return new List<MenuItemData<ShapeEditorCommand>>()
            {
                createItem(ShapeEditorCommand.LayerEdit, Resources.layer_edit, "Edit Layer"),
                createItem(ShapeEditorCommand.LayerCreate, Resources.layer_create, "Create new layer"),
                createItem(ShapeEditorCommand.GeometryCreate, Resources.geometry_create, "Add geometry"),
                createItem(ShapeEditorCommand.GeometryCreate, Resources.vertex_editor, "Vertex editor"),
            };
        }

        public override void RunCommand(ShapeEditorCommand command)
        {
            switch (command)
            {
                case ShapeEditorCommand.LayerEdit:
                    _layerService.ToggleVectorLayerEditing();
                    break;
                case ShapeEditorCommand.LayerCreate:
                    _layerService.CreateLayer();
                    break;
                case ShapeEditorCommand.VertexEditor:
                    _context.Map.MapCursor = MapCursor.EditShape;
                    break;
                case ShapeEditorCommand.GeometryCreate:
                    _context.Map.MapCursor = MapCursor.AddShape;
                    break;
            }
        }

        protected override void CommandNotFound(string itemName)
        {
            MessageBox.Show("Command for item not found: " + itemName);
        }
    }
}
