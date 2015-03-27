using System;
using System.Collections.Generic;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public interface IView
    {
        void ShowView(bool modal = true);
        void Close();
        void UpdateView();
        bool Visible { get; }
        event Action OkClicked;
    }
}
