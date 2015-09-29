using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Projections.BL;

namespace MW5.Projections.Views.Abstract
{
    public interface IProjectionInfoView : IComplexView<ProjectionInfoModel>
    {
        ProjectionDialect SelectedDialect { get; set; }

        event Action EditDialect;
    }
}
