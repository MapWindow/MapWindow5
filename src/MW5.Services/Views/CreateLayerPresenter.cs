using System;
using System.IO;
using System.Reflection;
using MW5.Api;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Views.Abstract;

namespace MW5.Services.Views
{
    public class CreateLayerPresenter: BasePresenter<ICreateLayerView>
    {
        private readonly ICreateLayerView _view;
        private readonly IMessageService _messageService;
        private readonly IFileDialogService _fileDialogService;
        private string _filename = string.Empty;

        public CreateLayerPresenter(ICreateLayerView view, IMessageService messageService, IFileDialogService fileDialogService) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (messageService == null) throw new ArgumentNullException("messageService");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");

            _view = view;
            _messageService = messageService;
            _fileDialogService = fileDialogService;
        }
        
        public string Filename
        {
            get { return _filename; }
        }

        public GeometryType GeometryType
        {
            get { return _view.GeometryType; }
        }

        public ZValueType ZValueType
        {
            get { return _view.ZValueType; }
        }

        public string LayerName
        {
            get { return _view.LayerName; }
        }

        public override bool ViewOkClicked()
        {
            string layerName = _view.LayerName;
            if (string.IsNullOrWhiteSpace(layerName))
            {
                _messageService.Info("Please enter a name of the new layer.");
                return false;
            }

            // TODO: pass parent window handle in some unobtrusive way
            string path = Directory.GetDirectoryRoot(Assembly.GetExecutingAssembly().Location);
            if (_fileDialogService.ChooseFolder(path, out path))
            {
                if (ValidateName(path))
                {
                    return true;
                }
            }

            return false;
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
    }
}
