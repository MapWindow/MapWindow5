using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Plugins.Mvp;

namespace MW5.Services.Views
{
    public interface ICreateLayerView : IView
    {
        event Action OkClicked;
        string LayerName { get; set; }
        GeometryType GeometryType { get; set; }
        ZValueType ZValueType { get; set; }
    }
}
