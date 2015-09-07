using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    public interface IParametrizedTool
    {
        ParameterCollection Parameters { get; }

        ToolConfiguration Configuration { get; }
    }
}
