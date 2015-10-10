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
using MW5.Tiles.Views.Abstract;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;

namespace MW5.Tiles.Views
{
    internal partial class WmsCapabilitiesView : WmsCapabilitiesViewBase, IWmsCapabilitiesView
    {
        public WmsCapabilitiesView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            cboServers.DataSource = Model.Repository.WmsServers;
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

        public override void UpdateView()
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
    }

    internal class WmsCapabilitiesViewBase : MapWindowView<WmsCapabilitiesModel> { }
}
