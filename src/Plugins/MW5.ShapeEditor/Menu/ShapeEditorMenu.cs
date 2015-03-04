using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MW5.Mvp;
using MW5.Mvp.Menu;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Properties;

namespace MW5.Plugins.ShapeEditor.Menu
{
    // TODO: add GetToolbarNames function
    internal class ShapeEditorMenu : PluginMenuBase<ShapeEditorCommand>
    {
        private const string PLUGIN_TOOLBAR_NAME = "Shape Editor";

        public ShapeEditorMenu(IAppContext context): base(context)
        {
            
            AddToolbar(PLUGIN_TOOLBAR_NAME);

            // adding menus
            var items = context.Menu.Items;
            items.AddDropDown(PLUGIN_TOOLBAR_NAME);
        }

        public override IEnumerable<MenuItemData<ShapeEditorCommand>> GetMenuItems(string toolBarName, 
            Func<ShapeEditorCommand, Bitmap, string, MenuItemData<ShapeEditorCommand>> createItem)
        {
            return new List<MenuItemData<ShapeEditorCommand>>()
            {
                createItem(ShapeEditorCommand.LayerEdit, Resources.layer_edit, "Edit Layer"),
                createItem(ShapeEditorCommand.GeometryCreate, Resources.geometry_create, "Add geometry"),
                createItem(ShapeEditorCommand.LayerCreate, Resources.layer_create, "Create new layer"),
                createItem(ShapeEditorCommand.LayerSave, Resources.layer_save, "Save changes")
            };
        }

        public override void RunCommand(ShapeEditorCommand command)
        {
            switch (command)
            {
                case ShapeEditorCommand.LayerEdit:
                    MessageBox.Show("Layer edit clicked");
                    break;
                case ShapeEditorCommand.LayerSave:
                    break;
                case ShapeEditorCommand.LayerCreate:
                    break;
                case ShapeEditorCommand.GeometryCreate:
                    break;
            }
        }

        protected override void CommandNotFound(string itemName)
        {
            Debug.Print("Command for item not found: " + itemName);
        }
    }
}
