using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Helpers;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Data.Repository;
using MW5.Data.Repository.Model;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Repository.Views
{
    public class RepositoryPresenter: CommandDispatcher<RepositoryDockPanel, RepositoryCommand>, IDockPanelProvider
    {
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly ILayerService _layerService;
        private readonly RepositoryDockPanel _view;

        public RepositoryPresenter(IAppContext context, RepositoryDockPanel view, IFileDialogService fileDialogService, ILayerService layerService)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (layerService == null) throw new ArgumentNullException("layerService");

            _context = context;
            _fileDialogService = fileDialogService;
            _layerService = layerService;
            _view = view;

            _view.ItemDoubleClicked += ViewItemDoubleClicked;

            var legend = context.Legend as ILegend;
            if (legend != null)
            {
                legend.LayerAdded += (s, e) => UpdateItemState();
                legend.LayerRemoved += (s, e) => UpdateItemState();
            }
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
                        var item = GetSelectedVectorItem<IFileItem>();

                        if (item.AddedToMap)
                        {
                            _layerService.RemoveLayer(item.Filename);
                        }
                        else
                        {
                            _layerService.AddLayersFromFilename(item.Filename);
                            int handle = _layerService.LastLayerHandle;
                            _context.Map.ZoomToLayer(handle);
                        }

                        break;
                    }
                case RepositoryCommand.RemoveFile:
                    {
                        var item = GetSelectedVectorItem<IFileItem>();

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

                        var vector = item as IFileItem;
                        if (vector != null)
                        {
                            path = vector.Filename;
                        }

                        PathHelper.OpenFolderWithExplorer(path);
                    }
                    break;
                case RepositoryCommand.GdalInfo:
                    {
                        var item = GetSelectedVectorItem<IFileItem>();
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
                    break;
                case RepositoryCommand.AddFolderToMap:
                    {
                        var folder = GetSelectedVectorItem<IFolderItem>();
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
                    break;
                case RepositoryCommand.Refresh:
                    {
                        var folder = GetSelectedVectorItem<IFolderItem>();
                        if (folder != null)
                        {
                            folder.Refresh();
                        }
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
            if (e.Item is IFileItem)
            {
                RunCommand(RepositoryCommand.AddToMap);
            }
        }

        protected override void CommandNotFound(string itemName)
        {
            MessageService.Current.Info("No handler was found for the item with key: " + itemName);
        }

        /// <summary>
        /// Marks items that were added to the map
        /// </summary>
        private void UpdateItemState()
        {
            var dict = _context.Map.GetFilenames().Select(n => n.ToLower()).Distinct().ToDictionary(item => item, item => item);

            var fs = View.Tree.GetSpecialItem(RepositoryItemType.FileSystem);
            if (fs != null)
            {
                UpdateState(fs.SubItems, dict);
            }
        }

        private void UpdateState(RepositoryItemCollection items, Dictionary<string, string> filenames )
        {
            foreach (var item in items)
            {
                var file = item as IFileItem;
                if (file != null)
                {
                    bool selected = filenames.ContainsKey(file.Filename.ToLower());
                    file.AddedToMap = selected;
                }

                var folder = item as IFolderItem;
                if (folder != null)
                {
                    UpdateState(folder.SubItems, filenames);
                }
            }
        }
    }
}
