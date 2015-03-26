using System.Collections.Generic;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public interface IView
    {
        void ShowView(bool dialog = true);
        void Close();
        void UpdateView();
        bool Visible { get; }
    }
}
