using System.Collections.Generic;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Views
{
    public interface IGisToolView: IView<GisToolBase>
    {
        void GenerateControls(IEnumerable<BaseParameter> parameters);
    }
}
