using System;
using System.IO;
using System.Reflection;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Views.Abstract;

namespace MW5.Services.Views
{
    public class CreateLayerPresenter: BasePresenter<ICreateLayerView, CreateLayerModel>
    {
        private readonly ICreateLayerView _view;
        private readonly IFileDialogService _fileDialogService;

        public CreateLayerPresenter(ICreateLayerView view, IFileDialogService fileDialogService) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");

            _view = view;
            _fileDialogService = fileDialogService;
        }
        
        public override bool ViewOkClicked()
        {
            string layerName = _view.LayerName;
            if (string.IsNullOrWhiteSpace(layerName))
            {
                MessageService.Current.Info("Please enter a name of the new layer.");
                return false;
            }

            if (!View.MemoryLayer)
            {
                string path = Directory.GetDirectoryRoot(Assembly.GetExecutingAssembly().Location);
                if (!_fileDialogService.ChooseFolder(path, out path))
                {
                    return false;
                }

                Model.Filename = GetFilename(path);
            }
            else
            {
                Model.Filename = View.LayerName;
            }

            Model.GeometryType = View.GeometryType;
            Model.ZValueType = View.ZValueType;
            Model.MemoryLayer = View.MemoryLayer;

            return true;
        }

        private string GetFilename(string path)
        {
            const string shpExt = ".shp";

            string filename = Path.Combine(path, _view.LayerName.ToLower());
            if (!filename.EndsWith(shpExt))
            {
                filename += shpExt;
            }

            return filename;
        }
    }
}
