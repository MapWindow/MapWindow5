using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using MW5.UI.Properties;
using MW5.UI.Repository.Model;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.UI
{
    internal sealed class RepositoryTreeView: TreeViewBase, IRepositoryView
    {
        public RepositoryTreeView()
        {
            ContextMenuStrip = CreateContextMenu();

            BeforeExpand += TreeViewBeforeExpand;

            AfterSelect += RepositoryTreeView_AfterSelect;

            PrepareToolTip += RepositoryTreeView_PrepareToolTip;

            LoadOnDemand = true;

            ToolTipDuration = 3000;
        }

        public event EventHandler<RepositoryEventArgs> ItemSelected;

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            return new[]
            {
                Resources.img_hard_disk,
                Resources.img_folder_open,
                Resources.img_point,
                Resources.img_line,
                Resources.img_polygon,
            };
        }

        private ContextMenuStripEx CreateContextMenu()
        {
            var contextMenu = new ContextMenuStripEx
            {
                ImageList = LeftImageList,
                Style = ContextMenuStripEx.ContextMenuStyle.Metro,
                RenderMode = ToolStripRenderMode.Professional
            };
            
            contextMenu.Items.Add("Remove link").Name = "mnuRemoveFolder";

            return contextMenu;
        }

        public RepositoryItemCollection Items
        {
            get { return new RepositoryItemCollection(Nodes); }
        }

        public IFolderItem CreateFolder(string path, bool root)
        {
            return RepositoryItem.CreateFolder(path, root);
        }

        public IRepositoryItem CreateItem(RepositoryItemType type)
        {
            return RepositoryItem.CreateItem(type);
        }

        public IVectorItem CreateVector(string filename)
        {
            return RepositoryItem.CreateVector(filename);
        }

        public IRepositoryItem GetSpecialItem(RepositoryItemType type)
        {
            return Items.FirstOrDefault(item => item.Type == type);
        }

        public IRepositoryItem SelectedItem
        {
            get
            {
                if (SelectedNode == null)
                {
                    return null;
                }

                return RepositoryItem.Get(SelectedNode);
            }
        }

        private void RepositoryTreeView_AfterSelect(object sender, EventArgs e)
        {
            FireItemSelected(SelectedNode);
        }

        private void TreeViewBeforeExpand(object sender, TreeViewAdvCancelableNodeEventArgs e)
        {
            var item = RepositoryItem.Get(e.Node) as IFolderItem;

            if (item != null)
            {
                item.Expand();
            }
        }

        private void FireItemSelected(TreeNodeAdv node)
        {
            var handler = ItemSelected;
            if (handler != null)
            {
                var item = RepositoryItem.Get(node);
                handler(this, new RepositoryEventArgs(item));
            }
        }

        private void RepositoryTreeView_PrepareToolTip(object sender, ToolTipEventArgs e)
        {
            var item = RepositoryItem.Get(SelectedNode);
            var vector = item as IVectorItem;
            if (vector == null)
            {
                e.Cancel = true;
                return;
            }

            string filename = vector.Filename;

            PopulateToolTip(e.ToolTip, filename);
        }

        private void PopulateToolTip(ToolTipInfo tooltip, string filename)
        {
            tooltip.Header.Text = Path.GetFileName(filename);

            string s;
            using (var ds = GeoSourceManager.Open(filename))
            {
                if (ds.LayerType == Api.LayerType.Shapefile)
                {
                    tooltip.Body.Text = "\n";

                    var fs = LayerSourceHelper.GetLayers(ds).FirstOrDefault() as IFeatureSet;
                    if (fs != null)
                    {
                        tooltip.Body.Text += "Geometry type: " + fs.GeometryType.EnumToString() + Environment.NewLine;
                        tooltip.Body.Text += "Feature count: " + fs.Features.Count + Environment.NewLine;
                        tooltip.Body.Text += "Projection: " + fs.Projection.ExportToProj4();
                    }
                }

                if (ds.LayerType == Api.LayerType.VectorLayer)
                {
                    tooltip.Body.Text = "\nLayers:";

                    foreach (var source in LayerSourceHelper.GetLayers(ds))
                    {
                        var layer = source as IVectorLayer;
                        if (layer != null)
                        {
                            tooltip.Body.Text += "\nLayer name: " + layer.Name + Environment.NewLine;
                            tooltip.Body.Text += "Geometry type: " + layer.GeometryType.EnumToString() + Environment.NewLine;
                            tooltip.Body.Text += "Feature count: " + layer.get_FeatureCount() + Environment.NewLine;
                        }
                    }
                }
            }
        }
    }
}
