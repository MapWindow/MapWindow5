// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMenuGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.UI.Menu;

namespace MW5.Plugins.Printing.Views
{
    internal class LayoutMenuGenerator
    {
        private readonly LayoutMenuCommands _commands;
        private readonly IMenuEx _menu;
        private readonly PrintingPlugin _plugin;
        private readonly IToolbarCollectionEx _toolbars;

        public LayoutMenuGenerator(PrintingPlugin plugin, ILayoutView view, LayoutMenuListener listener)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (view == null) throw new ArgumentNullException("view");
            if (listener == null) throw new ArgumentNullException("listener");

            _plugin = plugin;

            _commands = new LayoutMenuCommands(plugin.Identity);

            _menu = MenuFactory.CreateMenu(view.MenuManager);
            _toolbars = MenuFactory.CreateToolbars(view.MenuManager);

            InitMenu();

            InitToolbars();

            _menu.ItemClicked += listener.OnItemClicked;
            _toolbars.ItemClicked += listener.OnItemClicked;
        }

        public IMenuEx Menu
        {
            get { return _menu; }
        }

        public IToolbarCollectionEx Toolbars
        {
            get { return _toolbars; }
        }

        private void InitMenu()
        {
            // file
            var dropDown = _menu.Items.AddDropDown("File", "LayoutFileDropDown", _plugin.Identity);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.NewLayout]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.LoadLayout]).BeginGroup = true;
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.SaveLayout]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.SaveLayoutAs]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.PageSetup]).BeginGroup = true;
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.PrinterSetup]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.Print]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.Close]).BeginGroup = true;
            dropDown.Update();

            // view
            dropDown = _menu.Items.AddDropDown("View", "LayoutViewDropDown", _plugin.Identity);
            dropDown.SubItems.AddDropDown("Toolbars", null as Bitmap, _plugin.Identity);
            dropDown.SubItems.AddDropDown("Windows", null as Bitmap, _plugin.Identity);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.ZoomIn]).BeginGroup = true;
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.ZoomOut]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.ZoomMax]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.ShowPageNumbers]).BeginGroup = true;
            //dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.ShowMargins]);
            dropDown.Update();

            // selection
            dropDown = _menu.Items.AddDropDown("Selection", "LayoutSelectionDropDown", _plugin.Identity);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.SelectAll]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.SelectNone]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.InvertSelection]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.MoveUp]).BeginGroup = true;
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.MoveDown]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.ConvertToBitmap]).BeginGroup = true;
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.DeleteElement]).BeginGroup = true;
            dropDown.Update();

            // insert
            dropDown = _menu.Items.AddDropDown("Insert", "LayoutInsertDropDown", _plugin.Identity);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddMap]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddLegend]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddScaleBar]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddTable]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddRectangle]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddNorthArrow]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddLabel]);
            dropDown.SubItems.AddButton(_commands[LayoutMenuKeys.AddBitmap]);
            dropDown.Update();

            _menu.Update();
        }

        private void InitToolbars()
        {
            // insert
            var bar = _toolbars.Add("Insert", LayoutMenuKeys.InsertToolbar, _plugin.Identity);
            bar.DockState = ToolbarDockState.Left;
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddMap]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddLegend]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddScaleBar]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddTable]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddRectangle]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddNorthArrow]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddLabel]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.AddBitmap]);

            // map
            bar = _toolbars.Add("Map", LayoutMenuKeys.MapToolbar, _plugin.Identity);
            bar.DockState = ToolbarDockState.Left;
            bar.Items.AddButton(_commands[LayoutMenuKeys.MapZoomIn]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.MapZoomOut]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.MapZoomMax]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.MapPan]);

            // main
            bar = _toolbars.Add("Main", LayoutMenuKeys.MainToolbar, _plugin.Identity);
            bar.Items.AddButton(_commands[LayoutMenuKeys.NewLayout]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.LoadLayout]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.SaveLayout]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.SaveLayoutAs]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.PageSetup]).BeginGroup = true;
            bar.Items.AddButton(_commands[LayoutMenuKeys.AdjustPages]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.Print]).BeginGroup = true;;
            bar.Update();

            // zoom
            bar = _toolbars.Add("Zoom", LayoutMenuKeys.ZoomToolbar, _plugin.Identity);
            bar.Items.AddButton(_commands[LayoutMenuKeys.ZoomIn]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.ZoomOut]);
            bar.Items.AddButton(_commands[LayoutMenuKeys.ZoomMax]);

            bar.Items.AddLabel("Zoom:", LayoutMenuKeys.ZoomComboLabel, _plugin.Identity).BeginGroup = true;
            var combo = bar.Items.AddComboBox("75%", LayoutMenuKeys.ZoomCombo, _plugin.Identity);
            combo.DataSource.AddRange(new[] { "50%", "75%", "100%", "150%", "200%", "300%" });
            combo.Width = 75;
            bar.Update();
        }
    }
}