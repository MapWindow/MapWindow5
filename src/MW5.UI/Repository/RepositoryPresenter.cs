using System;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.UI.Repository.Model;
using MW5.UI.Repository.UI;

namespace MW5.UI.Repository
{
    public class RepositoryPresenter: CommandDispatcher<RepositoryDockPanel, RepositoryCommand>, IDockPanelProvider
    {
        private readonly IMuteMap _map;
        private readonly IFileDialogService _fileDialogService;
        private readonly ILayerService _layerService;
        private readonly RepositoryDockPanel _view;

        public RepositoryPresenter(IMuteMap map, RepositoryDockPanel view, IFileDialogService fileDialogService, ILayerService layerService)
            : base(view)
        {
            if (map == null) throw new ArgumentNullException("map");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (layerService == null) throw new ArgumentNullException("layerService");

            _map = map;
            _fileDialogService = fileDialogService;
            _layerService = layerService;
            _view = view;

            _view.ItemDoubleClicked += ViewItemDoubleClicked;
        }
        
        public Control GetInternalObject()
        {
            return _view;
        }

        public IRepository Repository
        {
            get { return _view.Repository; }
        }

        public override void RunCommand(RepositoryCommand command)
        {
            switch (command)
            {
                case RepositoryCommand.AddFolder:
                    {
                        string path;
                        if (_fileDialogService.ChooseFolder(string.Empty, out path))
                        {
                            Repository.AddFolderLink(path);
                        }
                    }
                    break;
                case RepositoryCommand.RemoveFolder:
                    if (MessageService.Current.Ask(
                            "Do you want to remove a link to this folder from the repository?" + Environment.NewLine + 
                            "(The folder will remain intact on the disk.)"))
                    {
                        var item = View.Tree.SelectedItem as IFolderItem;
                        if (item != null && item.Root)
                        {
                            Repository.RemoveFolderLink(item.GetPath());
                        }
                    }
                    break;
                case RepositoryCommand.AddToMap:
                    {
                        var item = GetSelectedVectorItem<IVectorItem>();

                        _layerService.AddLayersFromFilename(item.Filename);

                        int handle = _layerService.LastLayerHandle;
                        _map.ZoomToLayer(handle);

                        break;
                    }
                case RepositoryCommand.RemoveFile:
                    {
                        var item = GetSelectedVectorItem<IVectorItem>();

                        if (MessageService.Current.Ask("Do you want to remove the datasource: "
                            + Environment.NewLine + item.Filename + "?"))
                        {
                            try
                            {
                                var folder = item.Folder;
                                GeoSource.Remove(item.Filename);
                                folder.Refresh();
                            }
                            catch (Exception ex)
                            {
                                MessageService.Current.Warn("Failed to remove file: " + ex.Message);
                            }
                        }
                    }
                    break;
                case RepositoryCommand.OpenLocation:
                    {
                        var item = GetSelectedVectorItem<IRepositoryItem>();
                        string path = string.Empty;
                        var folder = item as IFolderItem;
                        if (folder != null)
                        {
                            path = folder.GetPath();
                        }

                        var vector = item as IVectorItem;
                        if (vector != null)
                        {
                            path = vector.Filename;
                        }

                        Plugins.Helpers.PathHelper.OpenFolderWithExplorer(path);
                    }
                    break;
            }
        }

        private T GetSelectedVectorItem<T>() where T: class, IRepositoryItem
        {
            var item = _view.Tree.SelectedItem as T;
            if (item == null)
            {
                throw new InvalidCastException("Selected item must support IVectorItem interface.");
            }

            return item;
        }

        private void ViewItemDoubleClicked(object sender, RepositoryEventArgs e)
        {
            if (e.Item is IVectorItem)
            {
                RunCommand(RepositoryCommand.AddToMap);
            }
        }

        protected override void CommandNotFound(string itemName)
        {
            MessageService.Current.Info("No handler was found for the item with key: " + itemName);
        }
    }
}
