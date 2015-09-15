using MW5.Plugins.Mvp;
using MW5.Tools.Views;

namespace MW5.Gdal.Views.Abstract
{
    public interface ITranslateRasterCustomView : IView<ToolViewModel>
    {
        string InputFilename { get; }
        string OutputFilename { get; }
        string Options { get; }
        string OutputFormat { get; }
        bool AddToMap { get; }
    }
}
