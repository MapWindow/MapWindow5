using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public interface IView : IViewInternal
    {
        void UpdateView();
        ButtonBase OkButton { get; }
    }
}
