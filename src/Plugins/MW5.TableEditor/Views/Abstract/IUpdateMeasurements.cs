using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface IUpdateMeasurementsView: IView<IFeatureSet>
    {
        MeasurementInfo AreaInfo { get; }
        MeasurementInfo LengthInfo { get; }
        AreaUnits AreaUnits { get; }
        LengthUnits LengthUnits { get; }
    }
}
