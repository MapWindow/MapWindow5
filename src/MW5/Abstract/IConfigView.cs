using System;
using System.Collections.Generic;
using MW5.Plugins.Mvp;
using MW5.Services.Config;

namespace MW5.Abstract
{
    public interface IConfigView: IView
    {
        List<IConfigPage> Pages { get; }
        void Initialize();
        event Action OkClicked;
        event Action OpenFolderClicked;
        event Action SaveClicked;
    }
}
