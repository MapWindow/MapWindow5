using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Mvp;

namespace MW5.Services.Views.Abstract
{
    public interface ICreateLayerView : IView
    {
        string LayerName { get; set; }
        GeometryType GeometryType { get; set; }
        ZValueType ZValueType { get; set; }
    }
}
