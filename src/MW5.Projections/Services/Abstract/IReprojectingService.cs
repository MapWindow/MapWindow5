using MW5.Api.Interfaces;
using MW5.Projections.Enums;
using MW5.Projections.Forms;

namespace MW5.Projections.Services.Abstract
{
    public interface IReprojectingService
    {
        TestingResult Reproject(ILayerSource layer, out ILayerSource newLayer, ISpatialReference projection,
            TesterReportForm report);
    }
}
