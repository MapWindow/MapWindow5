using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL.PluginManager;
//using BaseComponents.BaseClasses.Plugins;
using BaseComponents.BaseClasses.Forms;
//using BasePlugin = PluginInterface.BasePlugin;

namespace MapOptionsPlugin
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("PluginName", "MapOptionsPlugin")]
    public class Main : BasePlugin
    {
        const string MAPOPTIONS = "MapOptions";
        const string MAPOPTIONS_ZOOMIN = "MapOptionsZoomIn";
        const string MAPOPTIONS_ZOOMOUT = "MapOptionsZoomOut";
        private const string MAPOPTIONS_TOOLSTRIP = "MapOptionsToolStrip";
        private const string MAPOPTIONS_TOOL_ZOOMIN = "MapOptionsZoomInTool";

        //public event TickHandler Tick;
        //public EventArgs e = null;
        //public delegate void TickHandler(Metronome m, EventArgs e);


        protected override void CreateMenu()
        {
            if (MainForm.MainMenuStrip != null)
            {
                ToolStripMenuItem mapOptionsToolStripMenuItem = new ToolStripMenuItem(MAPOPTIONS, null, null, MAPOPTIONS);
                ToolStripItem zoomInToolStripItem = new ToolStripButton("ZoomIn", null, MainForm.MenuButtonClicked, MAPOPTIONS_ZOOMIN);
               
                zoomInToolStripItem.Tag = "MapOptionsPlugin";
                zoomInToolStripItem.AutoSize = false;
                zoomInToolStripItem.Width = 50;
                mapOptionsToolStripMenuItem.DropDownItems.Add(zoomInToolStripItem);


                ToolStripItem zoomOutToolStripItem = new ToolStripButton("ZoomOut", null, MainForm.MenuButtonClicked, MAPOPTIONS_ZOOMOUT);
                zoomOutToolStripItem.Tag = "MapOptionsPlugin";
                zoomOutToolStripItem.AutoSize = false;
                zoomOutToolStripItem.Width = 60;
                mapOptionsToolStripMenuItem.DropDownItems.Add(zoomOutToolStripItem);


                MainForm.MainMenuStrip.Items.Add(mapOptionsToolStripMenuItem);
            }
        }

        protected override void RemoveMenu()
        {
            if (MainForm.MainMenuStrip != null)
            {
                if (MainForm.MainMenuStrip.Items.ContainsKey(MAPOPTIONS))
                {
                    ToolStripMenuItem fileMenuItem = MainForm.MainMenuStrip.Items[MAPOPTIONS] as ToolStripMenuItem;

                    // Remove dropdown-items
                    fileMenuItem.DropDownItems.RemoveByKey(MAPOPTIONS_ZOOMIN);
                    fileMenuItem.DropDownItems.RemoveByKey(MAPOPTIONS_ZOOMOUT);

                    // Remove MenuItem if no dropdownitems exist
                    if (fileMenuItem.DropDownItems.Count == 0)
                    {
                        MainForm.MainMenuStrip.Items.RemoveByKey(MAPOPTIONS);
                    }
                }
            }
        }
        public override void MenuButtonClicked(string menuItem)
        {
            switch (menuItem)
            {
                case "MapOptionsZoomIn":
                    MessageBox.Show("zoomin");
                    break;
                case "MapOptionsZoomOut":
                    MessageBox.Show("zoomout");
                    break;
            }
        }

        public override void ToolButtonClicked(string toolButtonName, object[] args)
        {
            if (toolButtonName == MAPOPTIONS_TOOL_ZOOMIN)
            {
                MainForm.ZoomIn();
                //mapWinControl1.CursorMode = tkCursorMode.cmZoomIn;
            }
        }

        protected override void CreateToolbar()
        {
            ToolStripButton mapOptionButton = new ToolStripButton("ZoomIn", null, MainForm.ToolButtonClicked, MAPOPTIONS_TOOL_ZOOMIN);
            mapOptionButton.Tag = "MapOptionsPlugin";

            ToolStrip strip;

            Control[] controls = MainForm.ContainerToolstrip.TopToolStripPanel.Controls.Find(MAPOPTIONS_TOOLSTRIP, false);
            if (controls.Any())
            {
                strip = controls[0] as ToolStrip;
            }
            else
            {
                strip = new ToolStrip { Dock = DockStyle.Top, Name = MAPOPTIONS_TOOLSTRIP };
            }

            strip.Items.Add(mapOptionButton);
            MainForm.ContainerToolstrip.TopToolStripPanel.Controls.Add(strip);
        }

        protected override void RemoveToolbar()
        {
            if (MainForm.ContainerToolstrip != null)
            {
                Control[] controls = MainForm.ContainerToolstrip.TopToolStripPanel.Controls.Find(MAPOPTIONS_TOOLSTRIP, false);

                if (controls.Any())
                {
                    ToolStrip toolstrip = MainForm.ContainerToolstrip.TopToolStripPanel.Controls[MAPOPTIONS_TOOLSTRIP] as ToolStrip;
                    toolstrip.Items.RemoveByKey(MAPOPTIONS_TOOL_ZOOMIN);

                    if (toolstrip.Controls.Count == 0)
                    {
                        MainForm.ContainerToolstrip.TopToolStripPanel.Controls.RemoveByKey(MAPOPTIONS_TOOLSTRIP);
                    }
                }

            }
        }
    }
}
