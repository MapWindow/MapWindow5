using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Properties;

namespace MW5.Plugins.ShapeEditor.Menu
{
    internal class MenuGenerator
    {
        private const string ShapeEditorToolbar = "Shape Editor";    // perhaps simply use plugin name as a default
        
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, ShapeEditor plugin)
        {
            _commands = new MenuCommands(plugin.Identity);

            InitToolbar(context, plugin.Identity);

            InitMenu(context, plugin.Identity);
        }

        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            var items = context.Toolbars.FileToolbar.Items;
            items.AddButton(_commands[MenuKeys.CreateLayer]);

            var bar = context.Toolbars.Add(ShapeEditorToolbar, identity);
            bar.DockState = ToolbarDockState.Top;

            items = bar.Items;

            items.AddButton(_commands[MenuKeys.LayerEdit]);
            items.AddButton(_commands[MenuKeys.GeometryCreate], true);
            items.AddButton(_commands[MenuKeys.VertexEditor]);
            items.AddButton(_commands[MenuKeys.SplitShapes], true);
            items.AddButton(_commands[MenuKeys.MergeShapes]);
            items.AddButton(_commands[MenuKeys.MoveShapes]);
            items.AddButton(_commands[MenuKeys.RotateShapes]);
            items.AddButton(_commands[MenuKeys.Copy], true);
            items.AddButton(_commands[MenuKeys.Paste]);
            items.AddButton(_commands[MenuKeys.Cut]);

            var dropDown = items.AddDropDown("Polygon Overlay", MenuKeys.PolygonOverlayDropDown, identity);
            dropDown.BeginGroup = true;
            dropDown.Icon = new MenuIcon(Resources.icon_geometry_erase_by_polygon);

            dropDown.SubItems.AddButton(_commands[MenuKeys.EraseByPolygon]);
            dropDown.SubItems.AddButton(_commands[MenuKeys.ClipByPolygon]);
            dropDown.SubItems.AddButton(_commands[MenuKeys.SplitByPolygon]);

            items.AddButton(_commands[MenuKeys.SplitByPolyline]);
            items.AddButton(_commands[MenuKeys.Undo], true);

            items.AddLabel("0/0", MenuKeys.HistoryLength, identity);

            items.AddButton(_commands[MenuKeys.Redo]);

            bar.Update();
        }

        private void InitMenu(IAppContext context, PluginIdentity identity)
        {
            var menu = context.Menu.Items;
            menu.InsertBefore = context.Menu.ViewMenu;

            var bar = menu.AddDropDown("Edit", MenuKeys.MainMenuEditKey, identity);

            menu.InsertBefore = context.Menu.HelpMenu;

            var items = bar.SubItems;

            items.AddButton(_commands[MenuKeys.Undo]);
            items.AddButton(_commands[MenuKeys.Redo]);

            items.AddButton(_commands[MenuKeys.Copy], true);
            items.AddButton(_commands[MenuKeys.Paste]);
            items.AddButton(_commands[MenuKeys.Cut]);

            items.AddButton(_commands[MenuKeys.DeleteSelected], true);

            bar.Update();
        }
    }    
}
