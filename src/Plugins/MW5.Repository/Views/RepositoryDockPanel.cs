// -------------------------------------------------------------------------------------------
// <copyright file="RepositoryDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Data.Enums;
using MW5.Data.Helpers;
using MW5.Data.Repository;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Plugins.Repository.Views
{
    /// <summary>
    /// Represents dock panel which holds repository tree view, toolbar and description area.
    /// </summary>
    public partial class RepositoryDockPanel : DockPanelControlBase, IMenuProvider
    {
        public RepositoryDockPanel(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            InitializeComponent();

            InitTreeView(repository);

            contextMenuStripEx1.Opening += contextMenuStripEx1_Opening;

            toolRemoveFolder.Enabled = false;

            Init();
        }

        public override void SetFocus()
        {
            treeViewAdv1.Focus();
        }

        public event EventHandler<RepositoryEventArgs> ItemDoubleClicked;

        public event KeyEventHandler RepositoryKeyDown
        {
            add { treeViewAdv1.KeyDown += value; }
            remove { treeViewAdv1.KeyDown -= value; }
        }

        public IRepositoryView Tree
        {
            get { return treeViewAdv1; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
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
            splitContainerAdv1.InitDockPanel(0.85);

            richTextBox1.InitDockPanelFooter();
            richTextBox1.Text = "No datasource is selected.";
            richTextBox1.DetectUrls = false;
        }

        private void InitTreeView(IRepository repository)
        {
            treeViewAdv1.InitRepository(repository);

            treeViewAdv1.ItemSelected += OnTreeViewItemSelected;
            treeViewAdv1.DoubleClick += (s, e) => FireItemDoubleClicked();
            treeViewAdv1.ShowToolTip = false;
        }

        private void OnTreeViewItemSelected(object sender, RepositoryEventArgs e)
        {
            UpdateDescription(e.Item);

            var folder = e.Item as IFolderItem;
            toolRemoveFolder.Enabled = folder != null && folder.Root;
        }

        private void SetDatabaseContextMenu()
        {
            contextMenuStripEx1.Items.AddRange(new ToolStripItem[]
                                                   { mnuRemoveConnection, new ToolStripSeparator(), mnuRefresh });
        }

        private void SetDatabaseLayerContextMenu(IDatabaseLayerItem layer)
        {
            mnuAddToMap.Text = layer.AddedToMap ? "Remove from the Map" : "Add to the Map";

            contextMenuStripEx1.Items.AddRange(new ToolStripItem[]
                                                   { mnuAddToMap, new ToolStripSeparator(), mnuRemoveLayer });
        }

        private void SetDatabaseRootContextMenu()
        {
            contextMenuStripEx1.Items.Add(mnuAddConnection);
        }

        private void SetFileContextMenu(IFileItem file)
        {
            mnuAddToMap.Text = file.AddedToMap ? "Remove From the Map" : "Add to the Map";

            contextMenuStripEx1.Items.AddRange(new ToolStripItem[]
                                                   {
                                                       mnuAddToMap, new ToolStripSeparator(), mnuGdalInfo, mnuOpenLocation,
                                                       new ToolStripSeparator(), mnuRemoveFile
                                                   });
        }

        private void SetFileSystemContextMenu()
        {
            contextMenuStripEx1.Items.Add(mnuAddFolder);
        }

        private void SetFolderContextMenu(IFolderItem folder)
        {
            contextMenuStripEx1.Items.AddRange(new ToolStripItem[] { mnuAddFolderToMap, new ToolStripSeparator() });

            if (folder.Root)
            {
                contextMenuStripEx1.Items.Add(mnuRemoveFolder);
            }

            contextMenuStripEx1.Items.AddRange(new ToolStripItem[]
                                                   { mnuOpenLocation, new ToolStripSeparator(), mnuRefresh });
        }

        private void SetTmsProviderContextMenu()
        {
            var items = contextMenuStripEx1.Items;
            items.Add(mnuAddToMap);
            items.Add(new ToolStripSeparator());

            var tms = Tree.SelectedItem as ITmsItem;
            if (tms != null && tms.Provider.IsCustom)
            {
                items.Add(toolRemoveTms);
                items.Add(new ToolStripSeparator());
            }

            items.Add(toolProperties);
        }

        private void SetTmsRootContextMenu()
        {
            contextMenuStripEx1.Items.AddRange(new ToolStripItem[] { 
                toolAddTms, 
                new ToolStripSeparator(), 
                toolImportTms, 
                toolClearTms,  
                new ToolStripSeparator(), 
                toolHelp 
            });
        }

        private void UpdateDescription(IRepositoryItem item)
        {
            Logger.Current.Debug("In UpdateDescription");
            richTextBox1.SetText("Loading...");

            Task<string>.Factory.StartNew(item.GetDescription).ContinueWith(description =>
                {
                    try
                    {
                        string msg = string.Format("{0}{2}{2}{1}", item.DisplayName, description.Result,
                            Environment.NewLine);
                        Logger.Current.Debug(msg);
                        richTextBox1.SetDescription(msg);
                    }
                    catch (Exception ex)
                    {
                        Logger.Current.Error("Failed to load datasource description: {0}", ex, item.DisplayName);
                        richTextBox1.SetText("Failed to load description.");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void contextMenuStripEx1_Opening(object sender, CancelEventArgs e)
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
                case RepositoryItemType.TmsRoot:
                    SetTmsRootContextMenu();
                    return;
                case RepositoryItemType.TmsSource:
                    SetTmsProviderContextMenu();
                    return;
                case RepositoryItemType.FileSystem:
                    SetFileSystemContextMenu();
                    return;
                case RepositoryItemType.Server:
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
                    SetDatabaseLayerContextMenu(item as IDatabaseLayerItem);
                    return;
            }

            e.Cancel = true;
        }
    }
}