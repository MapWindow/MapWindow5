using System.Windows.Forms;
using MW5.Plugins.Mvp;

namespace MW5.Tools.Views.Custom.Abstract
{
    public interface ILongExecutionView: IView<ToolViewModel>
    {
        double SecondsPerStep { get; }

        bool RunInBackground { get; }

        ProgressBar Progress { get; }

        void DisableButtons();
    }
}
