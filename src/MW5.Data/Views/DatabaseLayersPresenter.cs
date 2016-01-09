using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

namespace MW5.Data.Views
{
    public class DatabaseLayersPresenter: BasePresenter<IDatabaseLayersView, DatabaseLayersModel>
    {
        private readonly ILayerService _layerService;
        private SynchronizationContext _syncContext;

        public DatabaseLayersPresenter(IDatabaseLayersView view, ILayerService layerService) : base(view)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
            _layerService = layerService;
        }

        public override bool ViewOkClicked()
        {
            View.StartWait();

            var layers = View.Layers.Where(l => l.Selected).ToList();

            if (layers.Count == 0)
            {
                MessageService.Current.Info("No layers are selected.");
                return false;
            }

            _syncContext = SynchronizationContext.Current;
            
            _layerService.BeginBatch();

            Task.Factory.StartNew(() =>
            {
                foreach (var info in layers)
                {
                    var layer = new VectorLayer();
                    if (layer.Open(info.Layer.ConnectionString, info.Layer.Name))
                    {
                        var data = layer.Data;
                        AddLayerToMap(layer);
                    }
                }
            })
            .ContinueWith(t =>
            {
                _layerService.EndBatch();

                View.StopWait();

                ReturnValue = true;
                View.Close();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            return false;
        }

        private void AddLayerToMap(VectorLayer layer)
        {
            _syncContext.Post(o => _layerService.AddDatasource(layer), layer);
        }
    }
}
