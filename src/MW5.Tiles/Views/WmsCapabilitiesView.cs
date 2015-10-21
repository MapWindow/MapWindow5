using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BruTile.Wms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Tiles.Properties;
using MW5.Tiles.Views.Abstract;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
using Action = System.Action;

namespace MW5.Tiles.Views
{
    internal partial class WmsCapabilitiesView : WmsCapabilitiesViewBase, IWmsCapabilitiesView
    {
        public WmsCapabilitiesView()
        {
            InitializeComponent();

            layersTreeView.NodeMouseDoubleClick += (s, e) => Invoke(LayerDoubleClicked);
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            PopulateImageList();

            // icons aren't displayed when binding is on
            //cboServers.DataSource = Model.Repository.WmsServers;

            RefreshServerList();
        }

        private void RefreshServerList()
        {
            var server = cboServers.SelectedItem as WmsServer;

            cboServers.Items.Clear();

            foreach (var s in Model.Repository.WmsServers)
            {
                cboServers.Items.Add(s);
            }

            RefreshComboBoxImages();

            if (server != null)
            {
                cboServers.SelectedItem = server;
            }
            else if(cboServers.Items.Count > 0)
            {
                cboServers.SelectedIndex = 0;
            }
        }

        public override Plugins.Mvp.ViewStyle Style
        {
            get { return new Plugins.Mvp.ViewStyle(true); }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get  { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnAdd;
                yield return btnConnect;
                yield return btnCreate;
                yield return btnDelete;
                yield return btnEdit;
            }
        }

        public WmsServer Server
        {
            get { return cboServers.SelectedItem as WmsServer; }
            set { cboServers.SelectedItem = value; }
        }

        public void ShowHourglass()
        {
            btnConnect.Enabled = false;
            Cursor = Cursors.WaitCursor;
        }

        public void HideHourglass()
        {
            btnConnect.Enabled = true;
            Cursor = Cursors.Default;
        }

        public IEnumerable<Layer> SelectedLayers
        {
            get
            {
                foreach (TreeNodeAdv node in layersTreeView.SelectedNodes)
                {
                    yield return node.Tag as Layer;
                }
            }
        }

        public event Action LayerDoubleClicked;

        public override void UpdateView()
        {
            RefreshServerList();

            UpdateLayers();
        }

        private void UpdateLayers()
        {
            layersTreeView.Nodes.Clear();

            if (Model.Capabilities == null)
            {
                return;
            }

            var layer = Model.Capabilities.Capability.Layer;

            var node = CreateNode(layer, layersTreeView.Nodes);

            if (node != null)
            {
                node.Expand();

                layersTreeView.SelectedNode = node;
            }
        }

        private TreeNodeAdv CreateNode(Layer layer, TreeNodeAdvCollection nodes)
        {
            // TODO: move to control
            if (layer == null)
            {
                return null;
            }

            var node = new TreeNodeAdv(layer.Title) { Tag = layer };
            node.SubItems.Add(new TreeNodeAdvSubItem(string.Join(";", layer.SRS)));
            nodes.Add(node);

            foreach (var l in layer.ChildLayers)
            {
                CreateNode(l, node.Nodes);
            }

            return node;
        }

        private void PopulateImageList()
        {
            var list = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };
            list.Images.Add(Resources.img_globe16);
            cboServers.ShowImageInTextBox = true;
            cboServers.ShowImagesInComboListBox = true;
            cboServers.ImageList = list;
        }

        private void RefreshComboBoxImages()
        {
            for (int i = 0; i < cboServers.Items.Count; i++)
            {
                cboServers.ImageIndexes[i] = 0;
            }
        }
    }

    internal class WmsCapabilitiesViewBase : MapWindowView<WmsCapabilitiesModel> { }
}
