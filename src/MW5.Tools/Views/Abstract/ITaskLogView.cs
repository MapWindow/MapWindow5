using System;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Tools.Views.Abstract
{
    internal interface ITaskLogView: IView<IGisTask>
    {
        event Action Cancel;

        event Action Pause;
    }
}
