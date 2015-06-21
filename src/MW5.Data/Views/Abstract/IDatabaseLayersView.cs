using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Data.Model;
using MW5.Plugins.Mvp;

namespace MW5.Data.Views.Abstract
{
    public interface IDatabaseLayersView: IView<VectorDatasource>
    {
        IEnumerable<VectorLayerInfo> Layers { get; }
    }
}
