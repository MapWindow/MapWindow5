using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api;
using MW5.Mvp;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Properties;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor.Menu
{
    internal class MenuGenerator
    {
        private const string SHAPE_EDITOR_TOOLBAR = "Shape Editor";    // perhaps simply use plugin name as a default
        
        private readonly MenuCommands _commands;

        public MenuGenerator(IAppContext context, ShapeEditor plugin)
        {
            _commands = new MenuCommands(plugin.Identity);

            InitToolbar(context, plugin.Identity);

            InitMenu();
        }

        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            var bar = context.Toolbars.Add(SHAPE_EDITOR_TOOLBAR, identity);
            bar.DockState = ToolbarDockState.Top;

            var items = bar.Items;

            _commands.AddToMenu(items, MenuKeys.LayerEdit);
            _commands.AddToMenu(items, MenuKeys.GeometryCreate, true);
            _commands.AddToMenu(items, MenuKeys.VertexEditor);
            _commands.AddToMenu(items, MenuKeys.SplitShapes, true);
            _commands.AddToMenu(items, MenuKeys.MergeShapes);
            _commands.AddToMenu(items, MenuKeys.MoveShapes);
            _commands.AddToMenu(items, MenuKeys.RotateShapes);
            _commands.AddToMenu(items, MenuKeys.Copy, true);
            _commands.AddToMenu(items, MenuKeys.Paste);
            _commands.AddToMenu(items, MenuKeys.Cut);

            var dropDown = items.AddDropDown("Polygon Overlay", MenuKeys.PolygonOverlayDropDown, identity);
            dropDown.BeginGroup = true;
            dropDown.Icon = new MenuIcon(Resources.geometry_erase_by_polygon);

            _commands.AddToMenu(dropDown.SubItems, MenuKeys.EraseByPolygon);
            _commands.AddToMenu(dropDown.SubItems, MenuKeys.ClipByPolygon);
            _commands.AddToMenu(dropDown.SubItems, MenuKeys.SplitByPolygon);

            _commands.AddToMenu(items, MenuKeys.SplitByPolyline);
            _commands.AddToMenu(items, MenuKeys.Undo, true);

            items.AddLabel("0/0", MenuKeys.HistoryLength, identity);

            _commands.AddToMenu(items, MenuKeys.Redo);
            
            bar.Update();
        }

        private void InitMenu()
        {
            
        }
    }    
}
