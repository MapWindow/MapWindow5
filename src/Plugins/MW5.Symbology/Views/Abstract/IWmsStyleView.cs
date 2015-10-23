using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Symbology.Views.Abstract
{
    internal interface IWmsStyleView: IComplexView<ILegendLayer>
    {
        bool ValidateInput();

        void ApplyChanges();

        void ClearColorAdjustments();
    }
}
