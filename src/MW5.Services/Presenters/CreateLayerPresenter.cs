using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Plugins.Mvp;
using MW5.Services.Services.Abstract;
using MW5.Services.Views;

namespace MW5.Services.Presenters
{
    public class CreateLayerPresenter: BasePresenter<ICreateLayerView>
    {
        private readonly ICreateLayerView _view;
        private readonly IMessageService _messageService;
        private readonly IFileDialogService _fileDialogService;
        private string _filename = string.Empty;
        private bool _success = false;

        public CreateLayerPresenter(ICreateLayerView view, IMessageService messageService, IFileDialogService fileDialogService) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (messageService == null) throw new ArgumentNullException("messageService");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");

            _view = view;
            _messageService = messageService;
            _fileDialogService = fileDialogService;

            view.OkClicked += view_OkClicked;
        }

        private void view_OkClicked()
        {
            string layerName = _view.LayerName;
            if (string.IsNullOrWhiteSpace(layerName))
            {
                _messageService.Info("Please enter a name of the new layer");
                return;
            }

            // TODO: pass parent window handle in some unobtrusive way
            string path = Directory.GetDirectoryRoot(Assembly.GetExecutingAssembly().Location);
            if (_fileDialogService.ChooseFolder(path, out path))
            {
                if (ValidateName(path))
                {
                    _success = true;
                    _view.Close();
                }
            }
        }

        private bool ValidateName(string path)
        {
            _filename = path + LayerName.ToLower();
            if (!_filename.EndsWith(".shp"))
            {
                _filename += ".shp";
            }
            return true;
        }

        public string Filename
        {
            get { return _filename; }
        }

        public GeometryType GeometryType
        {
            get { return _view.GeometryType; }
        }

        public string LayerName
        {
            get { return _view.LayerName; }
        }

        public bool Success
        {
            get { return _success; }
        }
    }
}
