using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model.Parameters;

namespace MW5.Gdal.Views.Abstract
{
    public interface IGdalDriverOptionsView: IGdalView
    {
        IEnumerable<BaseParameter> DriverParameters { get; }
    }
}
