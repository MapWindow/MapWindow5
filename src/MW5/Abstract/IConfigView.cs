using System;
using System.Collections.Generic;
using MW5.Plugins.Mvp;
using MW5.Services.Config;

namespace MW5.Abstract
{
    public interface IConfigView: IView
    {
        List<IConfigPage> Pages { get; }
        event Action OkClicked;
        void Initialize();
    }
}
