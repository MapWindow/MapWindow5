using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Mvp;
using MW5.Plugins.Mvp;
using MW5.Views;

namespace MW5.Abstract
{
    public interface ISetProjectionView : IView
    {
        SetProjectionView.ProjectionType Projection { get; }
        string CustomProjection { get; }
        int DefaultProjectionIndex { get; }
        event Action OkClicked;
    }
}
