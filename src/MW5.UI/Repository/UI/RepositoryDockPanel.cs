using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Repository.Model;

namespace MW5.UI.Repository.UI
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
            var folders = Tree.CreateItem(RepositoryItemType.FileSystem);
            Tree.Items.Add(folders, true);
            
            foreach (var path in _repository.Folders)
            {
                var folder = Tree.CreateFolder(path, true);
                folders.SubItems.Add(folder, true);
            }
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

        private void RepositoryFolderRemoved(object sender, Plugins.Concrete.FolderEventArgs e)
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
            var folder = Tree.CreateFolder(e.Path, true);
            item.SubItems.Add(folder, true);
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

            if (item is IVectorItem)
            {
                mnuAddToMap.Visible = true;
                mnuRemoveFile.Visible = true;
                mnuOpenLocation.Visible = true;
                toolStripSeparator2.Visible = true;
            }

            var folder = item as IFolderItem;
            if (folder != null )
            {
                mnuOpenLocation.Visible = true;

                if (folder.Root)
                {
                    mnuRemoveFolder.Visible = true;
                    toolStripSeparator2.Visible = true;
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
