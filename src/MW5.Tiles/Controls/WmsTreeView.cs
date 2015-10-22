// -------------------------------------------------------------------------------------------
// <copyright file="WmsTreeView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using BruTile.Wms;
using MW5.Shared;
using MW5.Tiles.Properties;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tiles.Controls
{
    /// <summary>
    /// A treeview to display list of layers provided by WMS server.
    /// </summary>
    public partial class WmsTreeView : TreeViewBase
    {
        public WmsTreeView()
        {
            InitializeComponent();
            PrepareToolTip += WmsTreeView_PrepareToolTip;
        }

        public Layer SelectedLayer
        {
            get
            {
                if (SelectedNode == null)
                {
                    return null;
                }

                return SelectedNode.Tag as Layer;
            }
        }

        public void DisplayLayers(Layer layer)
        {
            Nodes.Clear();

            AddLayer(layer, Nodes);

            Expand(Nodes);
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            yield return Resources.img_folder_open;
            yield return Resources.img_raster;
        }

        private void Expand(TreeNodeAdvCollection nodes)
        {
            bool stop = false;
            foreach (TreeNodeAdv node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    stop = true;
                    break;
                }
            }

            if (!stop)
            {
                foreach (TreeNodeAdv node in nodes)
                {
                    node.Expand();
                    Expand(node.Nodes);
                }
            }
        }

        private Layer GetLayer(TreeNodeAdv node)
        {
            return node.Tag as Layer;
        }

        private void AddLayer(Layer layer, TreeNodeAdvCollection nodes)
        {
            string name = layer.Name;
            if (nodes == Nodes && string.IsNullOrWhiteSpace(name))
            {
                name = string.IsNullOrWhiteSpace(layer.Title) ? "<root>" : layer.Title;
            }

            var node = nodes.Add(string.Empty, name, layer.ChildLayers.Any() ? 0 : 1);
            node.Tag = layer;

            Comparison<Layer> d = (l1, l2) =>
                {
                    // display folders at the top
                    if (l1.ChildLayers.Any() && !l2.ChildLayers.Any())
                    {
                        return -1;
                    }

                    if (!l1.ChildLayers.Any() && l2.ChildLayers.Any())
                    {
                        return 1;
                    }

                    return String.Compare(l1.Name, l2.Name, StringComparison.Ordinal);
                };

            layer.ChildLayers.Sort(d);

            foreach (var l in layer.ChildLayers)
            {
                AddLayer(l, node.Nodes);
            }
        }

        private void WmsTreeView_PrepareToolTip(object sender, ToolTipEventArgs e)
        {
            var layer = SelectedLayer;

            if (layer == null)
            {
                e.Cancel = true;
                return;
            }

            bool hasTitle = !string.IsNullOrWhiteSpace(layer.Title) && !layer.Title.EqualsIgnoreCase(layer.Name);
            bool hasAbstract = !string.IsNullOrWhiteSpace(layer.Abstract);

            if (!hasTitle && !hasAbstract)
            {
                e.Cancel = true;
                return;
            }

            e.ToolTip.Header.Text = layer.Name;

            var sb = new StringBuilder();

            if (hasTitle)
            {
                sb.Append("Title: " + layer.Title);
            }

            if (hasAbstract)
            {
                if (sb.Length > 0)
                {
                    sb.AppendLine();
                }

                sb.Append("Abstract: " + layer.Abstract);
            }

            e.ToolTip.Body.Text = sb.ToString();
        }
    }
}