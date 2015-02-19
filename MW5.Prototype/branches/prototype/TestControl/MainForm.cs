using System;
using System.Linq;
using System.Windows.Forms;
using BL.BO;
using BL.BusinessLogic;
using System.IO;
using MapWinGIS;
using BL.Utilities;
using BL.Aggregator;
using MapWindowControls.LegendControl;
using BaseComponents.BaseClasses.Forms;

namespace TestControl
{
    public partial class MainForm : BaseMainForm
    {
        // Maak nog iets als params[] aan extra gegevens/objecten aan de plugins mee te gaven

        private Aggregate aggregator;

        private const string CURRENT_DIR = @"C:\Dev\SampleData\Newton\";
        public MainForm()
        {
            InitializeComponent();

            aggregator = new Aggregate();
            aggregator.LayerControl = userControl11;
            aggregator.MapWin = this.mapWinControl1;
            aggregator.MainForm = this;

            ContainerToolstrip = toolStripContainer1;
            //SetToolContainer();



            Directory.SetCurrentDirectory(CURRENT_DIR);
            ProjectFileSettings.ReadProjectFile(CURRENT_DIR + @"Newton.mwprj", this.mapWinControl1, aggregator);

            // Create the plugin-menu
            SetPluginMenu();
        }

        //private void SetToolContainer()
        //{
        //    ToolstripContainer.AutoSize = true;
        //    ToolstripContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //    ToolstripContainer.Dock = DockStyle.Top;
        //    ToolstripContainer.FlowDirection = FlowDirection.LeftToRight;
        //    ToolstripContainer.WrapContents = true;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            mapWinControl1.CursorMode = tkCursorMode.cmZoomIn;

            //    mapWinControl1.SetCursorMode();

        }

        public override void ZoomIn()
        {
            mapWinControl1.CursorMode = tkCursorMode.cmZoomIn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mapWinControl1_FileDropped(object sender, MapWinControl._DMapEvents_FileDroppedEvent e)
        {
            int layerHandle = LayerLogic.AddLayer(e.filename, ZoomMode.ZoomToLayer, true, aggregator);

            //if(layerHandle != -1)
            //{
            //    Layer layer = new Layer();
            //    layer.Handle = layerHandle;
            //    layer.Filename = Path.GetFileName(e.filename);

            //    aggregator.AddLayer(layer);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProjectFileSettings.SaveProjectFile(aggregator, this.mapWinControl1, Path.Combine(CURRENT_DIR, "aapNew.mwprj"));

            //  ProjectFileSettings.SaveProjectFile(this, this.mapWinControl1, Path.Combine(CURRENT_DIR, "aapNew.mwprj"));
            return;
        }


        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void userControl11_SubmitClicked()
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aggregator.LayerAdded();

        }

        private void userControl11_LayerDropped(LegendDroppedEventArgs e)
        {
            bool isMoved  = LayerLogic.MoveLayer(e.destinationNode, e.movingNode, aggregator);

            if(!isMoved)
            {
                MessageBox.Show("Failed to move");
            }
        }

        private void userControl11_Checked(CheckedEventArgs e)
        {
            LayerLogic.ChangeVisibility(aggregator, e.ItemName, e.Visible, e.Handle, this.mapWinControl1);
        }


        private void SetPluginMenu()
        {
            ToolStripMenuItem pluginMenu = new ToolStripMenuItem("Plugins");
            menuStrip1.Items.Add(pluginMenu);

            var availablePlugins = aggregator.PluginFactory.AvailablePlugins();
            
            ToolStripMenuItem plugin;
            foreach (var name in availablePlugins)
            {
                plugin = new ToolStripMenuItem(name, null, Plugin_Clicked, name);
                pluginMenu.DropDownItems.Add(plugin);
                
                // TODO PM 9/4/2013: ActivePlugins is always null.
                if (aggregator.PluginFactory.ActivePlugins != null)
                {
                    plugin.Checked = aggregator.PluginFactory.ActivePlugins.Exists(elm => elm == name);
                }
            }
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Plugin_Clicked(object sender, EventArgs eventArgs)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                if (item.Checked)
                {
                    // unload the plugin
                    aggregator.PluginFactory.UnloadPlugin(item.Name);
                }
                else
                {
                    // Activate the plugin
                    aggregator.PluginFactory.CreatePlugin(item.Name, aggregator);
                }

                item.Checked = !item.Checked;


            }
            else
            {
                throw new Exception(String.Format("Error creating plugin"));
            }
        }

        public override void MenuButtonClicked(object sender, EventArgs args)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null && menuItem.Tag != null)
            {
                aggregator.PluginFactory.PluginMenuClicked(menuItem.Tag.ToString(), menuItem.Name);
            }
        }

        public override void ToolButtonClicked(object sender, EventArgs args)
        {
            ToolStripButton toolButton = sender as ToolStripButton;
            if (toolButton != null && toolButton.Tag != null)
            {
                aggregator.PluginFactory.PluginToolClicked(toolButton.Tag.ToString(), toolButton.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Layer layer = aggregator.Groups[1].Layers[0];
            //MessageBox.Show(layer.LayerType);
            ////   aggregator.MapWin.
            foreach (var layer in aggregator.CollectionLayer)
            {
                MessageBox.Show(layer.Name);
            }

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Layer layer in aggregator.CollectionLayer)
            {
                string aap = layer.Name + "  " + layer.Handle;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string x = string.Empty;
            foreach (LayerGroup layerGroup in aggregator.CollectionLayer.OrderBy(elm => elm.Position))
            {
                x += layerGroup.Position + " : " + layerGroup.Name + "\r\n";
            }

            MessageBox.Show(x);
        }

        private void userControl11_ColapseExand(LayerControl.LegendControl.ColapseExpandEventArgs e)
        {
            Group g = aggregator.CollectionLayer.GetGroup(e.NodeName);
            g.Expanded = e.IsExpanded;
        }
    }
}
