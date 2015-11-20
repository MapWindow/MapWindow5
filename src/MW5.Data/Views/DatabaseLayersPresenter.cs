using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

namespace MW5.Data.Views
{
    public class DatabaseLayersPresenter: BasePresenter<IDatabaseLayersView, DatabaseLayersModel>
    {
        private readonly ILayerService _layerService;

        public DatabaseLayersPresenter(IDatabaseLayersView view, ILayerService layerService) : base(view)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
            _layerService = layerService;
        }

        public override bool ViewOkClicked()
        {
            var layers = View.Layers.Where(l => l.Selected).ToList();

            if (layers.Count == 0)
            {
                MessageService.Current.Info("No layers are selected.");
                return false;
            }

            int count = 0;
            _layerService.BeginBatch();

            foreach (var info in layers)
            {
                if (_layerService.AddDatabaseLayer(info.Layer.ConnectionString, info.Layer.Name))
                {
                    count++;
                }
            }

            _layerService.EndBatch();

            MessageService.Current.Info("Layers added: " + count);

            return count > 0;
        }
    }
}
