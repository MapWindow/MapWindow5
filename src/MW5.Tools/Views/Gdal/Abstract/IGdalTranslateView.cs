using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views.Abstract;

namespace MW5.Tools.Views.Gdal.Abstract
{
    public interface IGdalTranslateView: IToolView
    {
        IEnumerable<BaseParameter> DriverParameters { get; }
    }
}
