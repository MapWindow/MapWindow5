using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Tools.Views.Custom
{
    public interface IRandomPointsView: IView<ToolViewModel>
    {
        int NumPoints { get; }
        ILayerSource Input { get; }
        string OutputName { get; }
    }
}
