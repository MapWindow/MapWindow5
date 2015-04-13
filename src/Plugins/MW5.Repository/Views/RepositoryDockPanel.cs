using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Data.Enums;
using MW5.Data.Repository;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.UI.Controls;

namespace MW5.Plugins.Repository.Views
{
    public partial class RepositoryDockPanel : DockPanelControlBase, IMenuProvider
    {
        public event EventHandler<RepositoryEventArgs> ItemDoubleClicked;

        public RepositoryDockPanel(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            InitializeComponent();

            treeViewAdv1.InitRepository(repository);

            treeViewAdv1.ItemSelected += treeViewAdv1_ItemSelected;
            treeViewAdv1.DoubleClick += (s, e) => FireItemDoubleClicked();

            contextMenuStripEx1.Opening += contextMenuStripEx1_Opening;

            toolRemoveFolder.Enabled = false;
        }

        private void FireItemDoubleClicked()
        {
            var handler = ItemDoubleClicked;
            if (handler != null)
            {
                var item = treeViewAdv1.SelectedItem;
                if (item != null)
                {
                    handler(treeViewAdv1, new RepositoryEventArgs(item));
                }
            }
        }

        public IRepositoryView Tree
        {
            get { return treeViewAdv1 as IRepositoryView; }
        }


        public IEnumerable<ToolStripItemCollection> Toolstrips
        {
            get
            {
                yield return toolStripEx1.Items;
                yield return treeViewAdv1.ContextMenuStrip.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        public IEnumerable<IToolbar> Toolbars
        {
            get { yield break; }
        }

        private void treeViewAdv1_ItemSelected(object sender, RepositoryEventArgs e)
        {
            var folder = e.Item as IFolderItem;
            toolRemoveFolder.Enabled = folder != null && folder.Root;
        }

        #region Context menu

        private void contextMenuStripEx1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var item = treeViewAdv1.SelectedItem;
            if (item == null)
            {
                e.Cancel = true;
                return;
            }

            contextMenuStripEx1.Items.Clear();

            switch (item.Type)
            {
                case RepositoryItemType.FileSystem:
                    SetFileSystemContextMenu();
                    return;
                case RepositoryItemType.PostGis:
                    SetDatabaseRootContextMenu();
                    return;
                case RepositoryItemType.Image:
                case RepositoryItemType.Vector:
                    SetFileContextMenu(item as IFileItem);
                    return;
                case RepositoryItemType.Folder:
                    SetFolderContextMenu(item as IFolderItem);
                    return;
                case RepositoryItemType.Database:
                    SetDatabaseContextMenu();
                    return;
                case RepositoryItemType.DatabaseLayer:
                    SetDatabaseLayerContextMenu();
                    return;
            }

            e.Cancel = true;
        }

        private void SetDatabaseLayerContextMenu()
        {
            // TODO: determine if the layer was already added
            contextMenuStripEx1.Items.Add(mnuAddToMap);
        }

        private void SetDatabaseContextMenu()
        {
            contextMenuStripEx1.Items.Add(mnuRemoveConnection);
        }

        private void SetDatabaseRootContextMenu()
        {
            contextMenuStripEx1.Items.Add(mnuAddConnection);
        }

        private void SetFileSystemContextMenu()
        {
            contextMenuStripEx1.Items.Add(mnuAddFolder);
        }

        private void SetFileContextMenu(IFileItem file)
        {
            mnuAddToMap.Text = file.AddedToMap ? "Remove from the map" : "Add to the map";

            contextMenuStripEx1.Items.AddRange(
            new ToolStripItem[]
                {
                    mnuAddToMap, 
                    new ToolStripSeparator(), 
                    mnuGdalInfo, 
                    mnuOpenLocation,
                    new ToolStripSeparator(), 
                    mnuRemoveFile
                });
        }

        private void SetFolderContextMenu(IFolderItem folder)
        {
            contextMenuStripEx1.Items.AddRange(new ToolStripItem[]
            {
                mnuAddFolderToMap, 
                new ToolStripSeparator(), 
            });

            if (folder.Root)
            {
                contextMenuStripEx1.Items.Add(mnuRemoveFolder);
            }

            contextMenuStripEx1.Items.AddRange(new ToolStripItem[]
            {
                mnuOpenLocation,
                new ToolStripSeparator(),
                mnuRefresh
            });
        }

        #endregion
    }
}
