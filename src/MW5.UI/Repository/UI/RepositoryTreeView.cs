using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.UI.Helpers;
using MW5.UI.Properties;
using MW5.UI.Repository.Model;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.UI
{
    internal sealed class RepositoryTreeView: TreeViewAdv, IRepositoryView
    {
        public RepositoryTreeView()
        {
            ContextMenuStrip = CreateContextMenu();

            LeftImageList = CreateImageList();

            BeforeExpand += TreeViewBeforeExpand;

            LoadOnDemand = true;
        }

        private ImageList CreateImageList()
        {
            return ImageListHelper.Create(new[]
            {
                Resources.img_hard_disk,
                Resources.img_folder_open,
                Resources.img_polygon
            }, 16);
        }

        private ContextMenuStripEx CreateContextMenu()
        {
            var contextMenu = new ContextMenuStripEx
            {
                ImageList = LeftImageList,
                Style = ContextMenuStripEx.ContextMenuStyle.Metro,
                RenderMode = ToolStripRenderMode.Professional
            };
            
            contextMenu.Items.Add("Remove link").Name = "mnuRemoveLink";

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

        private void TreeViewBeforeExpand(object sender, TreeViewAdvCancelableNodeEventArgs e)
        {
            var item = RepositoryItem.Get(e.Node) as IFolderItem;

            if (item != null)
            {
                item.Expand();
            }
        }
    }
}
