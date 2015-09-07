using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Views;

namespace MW5.Services.Concrete
{
    internal class SelectLayerService: ISelectLayerService
    {
        private readonly IAppContext _context;

        public SelectLayerService(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public IEnumerable<ILayer> Select(DataSourceType layerType)
        {
            var model = new SelectLayerModel(_context.Layers.Select(l => new LayerItem(l)), layerType);

            if (_context.Container.Run<SelectLayerPresenter, SelectLayerModel>(model))
            {
                return model.Layers.Where(l => l.Selected).Select(l => l.Layer);
            }

            return new List<ILayer>();
        }
    }
}
