using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Data.Enums;
using MW5.Data.Repository;
using MW5.Data.Views;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Repository.Views
{
    public class RepositoryPresenter: CommandDispatcher<RepositoryDockPanel, RepositoryCommand>, IDockPanelPresenter
    {
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly ILayerService _layerService;
        private readonly IRepository _repository;
        private readonly RepositoryDockPanel _view;

        public RepositoryPresenter(IAppContext context, RepositoryDockPanel view, 
                IFileDialogService fileDialogService, ILayerService layerService, IRepository repository)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (repository == null) throw new ArgumentNullException("repository");

            _context = context;
            _fileDialogService = fileDialogService;
            _layerService = layerService;
            _repository = repository;
            _view = view;

            _view.ItemDoubleClicked += ViewItemDoubleClicked;
        }

        public Control GetInternalObject()
        {
            return _view;
        }

        public override void RunCommand(RepositoryCommand command)
        {
            switch (command)
            {
                case RepositoryCommand.AddFolder:
                    _repository.AddFolderLink();
                    break;
                case RepositoryCommand.RemoveFolder:
                    RemoveFolder();
                    break;
                case RepositoryCommand.AddToMap:
                    AddLayerToMap();
                    break;
                case RepositoryCommand.RemoveFile:
                    RemoveFile();
                    break;
                case RepositoryCommand.OpenLocation:
                    OpenFileLocation();
                    break;
                case RepositoryCommand.GdalInfo:
                    ShowGdalInfo();
                    break;
                case RepositoryCommand.AddFolderToMap:
                    AddFolderToMap();
                    break;
                case RepositoryCommand.Refresh:
                    RefreshItem();
                    break;
                case RepositoryCommand.AddConnection:
                    AddConnection();
                    break;
                case RepositoryCommand.RemoveConnection:
                    RemoveConnection();
                    break;
                case RepositoryCommand.RemoveLayer:
                    RemoveDatabaseLayer();
                    break;
            }

            _context.View.Update();
        }

        private void RemoveDatabaseLayer()
        {
            var layer = GetSelectedItem<IDatabaseLayerItem>();
            if (layer != null)
            {
                var db = layer.Parent as IDatabaseItem;
                if (db != null)
                {
                    var ds = new VectorDatasource();
                    if (ds.Open(db.Connection.ConnectionString))
                    {
                        int layerIndex = ds.LayerIndexByName(layer.Name);
                        if (MessageService.Current.Ask("Do you want to remove database layer: " + layer.Name + "?"))
                        {
                            if (ds.DeleteLayer(layerIndex))
                            {
                                MessageService.Current.Info("Layer was removed: " + layer.Name);
                            }
                            else
                            {
                                MessageService.Current.Warn("Failed to remove layer.");
                            }

                            db.Refresh();
                        }
                    }
                }
            }
        }

        private void RemoveConnection()
        {
            var item = GetSelectedItem<IDatabaseItem>();
            if (item != null)
            {
                _repository.RemoveConnection(item.Connection, false);
            }
        }

        private void RemoveFolder()
        {
            var item = View.Tree.SelectedItem as IFolderItem;
            if (item != null && item.Root)
            {
                _repository.RemoveFolderLink(item.GetPath(), false);
            }
        }

        private void AddLayerToMap()
        {
            var layer = GetSelectedItem<ILayerItem>();
            if (layer == null)
            {
                return;
            }

            if (layer.AddedToMap)
            {
                _layerService.RemoveLayer(layer.Identity);
            }
            else
            {
                if (_layerService.AddLayerIdentity(layer.Identity))
                {
                    int handle = _layerService.LastLayerHandle;
                    _context.Map.ZoomToLayer(handle);
                }
            }
        }

        private void RemoveFile()
        {
            var item = GetSelectedItem<IFileItem>();

            if (item == null)
            {
                MessageService.Current.Info("No filename is selected.");
                return;
            }

            if (_context.Layers.Select(l => l.Identity).Contains(item.Identity))
            {
                MessageService.Current.Info("Can't remove datasource currently opened by the program.");
                return;
            }

            if (MessageService.Current.Ask("Do you want to remove the datasource: " + Environment.NewLine + item.Filename + "?"))
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

        private void OpenFileLocation()
        {
            var item = GetSelectedItem<IRepositoryItem>();
            string path = string.Empty;
            var folder = item as IFolderItem;
            if (folder != null)
            {
                path = folder.GetPath();
            }

            var vector = item as IFileItem;
            if (vector != null)
            {
                path = vector.Filename;
            }

            PathHelper.OpenFolderWithExplorer(path);
        }

        private void ShowGdalInfo()
        {
            var item = GetSelectedItem<IFileItem>();
            if (item != null)
            {
                if (item.Type == RepositoryItemType.Image)
                {
                    string info = GdalUtils.GdalInfo(item.Filename, "");
                    MessageService.Current.Info("GDAL info: \n\n" + info);
                }
                else if (item.Type == RepositoryItemType.Vector)
                {
                    string info = GdalUtils.OgrInfo(item.Filename, "", "");
                    MessageService.Current.Info("OGR info: \n\n" + info);
                }
            }
        }

        private void RefreshItem()
        {
            var item = GetSelectedItem<IRepositoryItem>();
            if (item is IFolderItem || item is IDatabaseItem)
            {
                item.Refresh();
            }
        }

        private void AddFolderToMap()
        {
            var folder = GetSelectedItem<IFolderItem>();
            if (folder != null)
            {
                _layerService.BeginBatch();

                try
                {
                    foreach (var item in folder.SubItems)
                    {
                        var file = item as IFileItem;
                        if (file != null)
                        {
                            _layerService.AddLayersFromFilename(file.Filename);
                        }
                    }
                }
                finally
                {
                    _layerService.EndBatch();
                }
            }
        }

        private void AddConnection()
        {
            var item = GetSelectedItem<IRepositoryItem>() as IServerItem;
            if (item != null)
            {
                _repository.AddConnectionWithPrompt(item.DatabaseType);
            }
        }

        private T GetSelectedItem<T>() where T: class, IRepositoryItem
        {
            var item = _view.Tree.SelectedItem as T;
            if (item == null)
            {
                throw new InvalidCastException("Invalid type of the selected item.");
            }

            return item;
        }

        private void ViewItemDoubleClicked(object sender, RepositoryEventArgs e)
        {
            if (e.Item is IFileItem || e.Item is IDatabaseLayerItem)
            {
                RunCommand(RepositoryCommand.AddToMap);
            }
        }
    }
}
