using MW5.Api.Interfaces;
using MW5.Projections.Enums;

namespace MW5.Projections.Services.Abstract
{
    public interface IProjectionMismatchService
    {
        TestingResult TestLayer(ILayerSource layer, out ILayerSource newLayer);
    }
}
