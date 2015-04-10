using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.Data.Properties;
using MW5.Data.Repository.Model;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository.UI
{
    internal sealed class RepositoryTreeView: TreeViewBase, IRepositoryView
    {
        public RepositoryTreeView()
        {
            BeforeExpand += TreeViewBeforeExpand;

            AfterSelect += RepositoryTreeView_AfterSelect;

            PrepareToolTip += RepositoryTreeView_PrepareToolTip;

            LoadOnDemand = true;

            ToolTipDuration = 3000;

            ItemDrag += RepositoryTreeView_ItemDrag;
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
                Resources.img_geometry,
                Resources.img_databases_16,
                Resources.img_database_16,
                Resources.img_postgis_16,
                Resources.img_raster
            };
        }

        public RepositoryItemCollection Items
        {
            get { return new RepositoryItemCollection(Nodes); }
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
            var vector = item as IFileItem;
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
            
            using (var ds = GeoSource.Open(filename))
            {
                tooltip.Body.Text = ds.ToolTipText;
            }
        }

        private void RepositoryTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var arr = e.Item as TreeNodeAdv[];
            if (arr == null || arr.Length == 0)
            {
                return;
            }

            var vectorItem = RepositoryItem.Get(arr[0]) as IFileItem;
            if (vectorItem != null)
            {
                DoDragDrop(vectorItem.Filename, DragDropEffects.Copy);
            }
        }
    }
}
