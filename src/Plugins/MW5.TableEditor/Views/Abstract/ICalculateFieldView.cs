using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.TableEditor.Views.Abstract
{
    public interface ICalculateFieldView: IView<IFeatureSet>
    {
        string Expression { get; }
        int TargetFieldIndex { get; }
    }
}
