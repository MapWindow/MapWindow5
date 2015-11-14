using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Mvp;

namespace MW5.Services.Views.Abstract
{
    public interface ICreateLayerView : IView<CreateLayerModel>
    {
        string LayerName { get; }
        GeometryType GeometryType { get; }
        ZValueType ZValueType { get; }
        bool MemoryLayer { get; }
    }
}
