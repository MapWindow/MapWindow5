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
        private const string SHAPE_EDITOR_TOOLBAR = "Shape editor";    // perhaps simply use plugin name as a default
        
        private readonly CommandProvider _commands;

        public MenuGenerator(IAppContext context, PluginIdentity identity)
        {
            InitToolbar(context, identity);

            InitMenu();
        }

        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            var bar = context.Toolbars.Add(SHAPE_EDITOR_TOOLBAR, identity);
            bar.DockState = ToolbarDockState.Top;

            var items = bar.Items;

            _commands.AddToMenu(items, MenuKeys.LayerEdit);
            _commands.AddToMenu(items, MenuKeys.LayerCreate);
            _commands.AddToMenu(items, MenuKeys.GeometryCreate, true);
            _commands.AddToMenu(items, MenuKeys.VertexEditor);
        }

        private void InitMenu()
        {
            
        }
    }    
}
