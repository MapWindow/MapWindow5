using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Views.Abstract
{
    public interface ILegendGroupView: IView<ILegendGroup>
    {
        string GroupName { get;  }
    }
}
