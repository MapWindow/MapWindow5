// -------------------------------------------------------------------------------------------
// <copyright file="WmsCapabilitiesView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BruTile.Wms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Mvp;
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

            wmsTreeView1.NodeMouseDoubleClick += (s, e) => Invoke(LayerDoubleClicked);

            cboServers.SelectedIndexChanged += (s, e) => Invoke(SelectedServerChanged);
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

        public override ViewStyle Style
        {
            get { return new ViewStyle(true); }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
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
                yield return wmsTreeView1.SelectedLayer;
            }
        }

        public event Action LayerDoubleClicked;

        public event Action SelectedServerChanged;

        public void UpdateCapabilities()
        {
            UpdateLayers();
        }

        public void UpdateServer(WmsServer server = null)
        {
            RefreshServerList();

            if (server != null)
            {
                Server = server;
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
            node.SubItems.Add(new TreeNodeAdvSubItem(layer.Title));
            node.SubItems.Add(new TreeNodeAdvSubItem(layer.Abstract));
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

        private void RefreshServerList()
        {
            cboServers.Items.Clear();

            foreach (var s in Model.Repository.WmsServers)
            {
                cboServers.Items.Add(s);
            }

            RefreshComboBoxImages();
        }

        private void UpdateLayers()
        {
            wmsTreeView1.Nodes.Clear();

            if (Model.Capabilities == null)
            {
                return;
            }

            var layer = Model.Capabilities.Capability.Layer;
            wmsTreeView1.DisplayLayers(layer);
        }
    }

    internal class WmsCapabilitiesViewBase : MapWindowView<WmsCapabilitiesModel>
    {
    }
}