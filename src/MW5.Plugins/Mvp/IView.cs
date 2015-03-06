using System.Collections.Generic;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public interface IView
    {
        void ShowView();
        void Close();
        void UpdateView();
    }

    public interface IMenuProvider
    {
        IEnumerable<IToolbar> Toolbars { get; }
    }

    public interface IComplexView: IView, IMenuProvider
    {
        
    }
}
