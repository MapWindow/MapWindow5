using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;

namespace MW5.Tools.Views.Gdal.Abstract
{
    public interface IGdalTranslateView : IView<ToolViewModel>
    {
        string InputFilename { get; }
        string OutputFilename { get; }
        string Options { get; }
        string OutputFormat { get; }
        bool AddToMap { get; }
    }
}
