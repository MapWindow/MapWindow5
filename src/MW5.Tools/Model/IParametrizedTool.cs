using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    public interface IParametrizedTool
    {
        bool Validate();

        ParameterCollection Parameters { get; }

        ToolConfiguration Configuration { get; }
    }
}
