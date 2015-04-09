using System;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.UI.Repository.Model;
using MW5.UI.Repository.UI;

namespace MW5.UI.Repository
{
    public class RepositoryPresenter: CommandDispatcher<RepositoryDockPanel, RepositoryCommand>, IDockPanelProvider
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly RepositoryDockPanel _view;

        public RepositoryPresenter(RepositoryDockPanel view, IFileDialogService fileDialogService)
            : base(view)
        {
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            
            _fileDialogService = fileDialogService;
            _view = view;
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
                    string path;
                    if (_fileDialogService.ChooseFolder(string.Empty, out path))
                    {
                        Repository.AddFolderLink(path);
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
            }
        }

        protected override void CommandNotFound(string itemName)
        {
            MessageService.Current.Info("No handler was found for the item with key: " + itemName);
        }
    }
}
