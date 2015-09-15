using System.Collections.Generic;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views.Abstract;

namespace MW5.Gdal.Views.Abstract
{
    public interface ITranslateRasterView: IToolView
    {
        IEnumerable<BaseParameter> DriverParameters { get; }
    }
}
