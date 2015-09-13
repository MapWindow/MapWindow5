using System;
using System.Linq.Expressions;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    public interface IParametrizedTool
    {
        ParameterCollection Parameters { get; }

        ToolConfiguration Configuration { get; }

        BaseParameter FindParameter<TTool, T>(Expression<Func<TTool, T>> layer);
    }
}
