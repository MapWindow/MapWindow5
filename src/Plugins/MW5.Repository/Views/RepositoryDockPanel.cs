using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Data.Repository;
using MW5.Data.Repository.Model;
using MW5.Data.Repository.UI;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;

namespace MW5.Plugins.Repository.Views
{
    public partial class RepositoryDockPanel : UserControl, IMenuProvider
    {
        private readonly IRepository _repository;

        public event EventHandler<RepositoryEventArgs> ItemDoubleClicked;

        public RepositoryDockPanel(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;

            InitializeComponent();

            Init();

            _repository.FolderAdded += RepositoryFolderAdded;
            _repository.FolderRemoved += RepositoryFolderRemoved;

            contextMenuStripEx1.Opening += ContextMenuStripOpening;

            treeViewAdv1.ItemSelected += treeViewAdv1_ItemSelected;
            treeViewAdv1.DoubleClick += (s, e) => FireItemDoubleClicked();

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

        private void Init()
        {
            // databases
            var dbs = Tree.Items.AddItem(RepositoryItemType.Databases);
            dbs.SubItems.AddItem(RepositoryItemType.PostGis);

            // file system
            var folders = Tree.Items.AddItem(RepositoryItemType.FileSystem);
            
            foreach (var path in _repository.Folders)
            {
                folders.SubItems.AddFolder(path, true);
            }

            folders.Expand();
        }

        public IRepositoryView Tree
        {
            get { return treeViewAdv1 as IRepositoryView; }
        }

        public IRepository Repository
        {
            get { return _repository; }
        }

        #region View

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

        private void RepositoryFolderRemoved(object sender, Concrete.FolderEventArgs e)
        {
            var item = Tree.GetSpecialItem(RepositoryItemType.FileSystem);
            var folder = item.SubItems.OfType<IFolderItem>().FirstOrDefault(f => f.GetPath().EqualsIgnoreCase(e.Path));
            if (folder != null)
            {
                item.SubItems.Remove(folder);
            }
        }

        private void RepositoryFolderAdded(object sender, Plugins.Concrete.FolderEventArgs e)
        {
            var item = Tree.GetSpecialItem(RepositoryItemType.FileSystem);
            item.SubItems.AddFolder(e.Path, true);
        }

        private void ContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var item = treeViewAdv1.SelectedItem;
            if (item == null)
            {
                e.Cancel = true;
                return;
            }

            foreach (ToolStripItem contextItem in contextMenuStripEx1.Items)
            {
                contextItem.Visible = false;
            }

            if (item.Type == RepositoryItemType.FileSystem)
            {
                mnuAddFolder.Visible = true;
            }

            var file = item as IFileItem;
            if (file != null)
            {
                mnuAddToMap.Text = file.AddedToMap ? "Remove from the map" : "Add to the map";
                mnuAddToMap.Visible = true;
                mnuRemoveFile.Visible = true;
                mnuOpenLocation.Visible = true;
                mnuGdalInfo.Visible = true;
                toolStripSeparator3.Visible = true;
                toolStripSeparator4.Visible = true;
            }

            var folder = item as IFolderItem;
            if (folder != null )
            {
                mnuOpenLocation.Visible = true;
                mnuRefresh.Visible = true;
                mnuAddFolderToMap.Visible = true;
                toolStripSeparator4.Visible = true;

                if (folder.Root)
                {
                    mnuRemoveFolder.Visible = true;
                    toolStripSeparator1.Visible = true;
                }
            }
        }

        private void treeViewAdv1_ItemSelected(object sender, RepositoryEventArgs e)
        {
            var folder = e.Item as IFolderItem;
            toolRemoveFolder.Enabled = folder != null && folder.Root;
        }

        #endregion
    }
}
