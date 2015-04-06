using MW5.Api.Interfaces;

namespace MW5.Projections.Services.Abstract
{
    public interface IProjectionMismatchService
    {
        TestingResult TestLayer(ILayerSource layer, out ILayerSource newLayer);
    }
}
