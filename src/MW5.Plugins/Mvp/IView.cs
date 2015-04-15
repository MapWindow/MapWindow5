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

    public interface IView<TModel> : IView, IViewInternal<TModel>
    {
        /// <summary>
        /// It's called internally before the view is shown. The UI should be populated here from this.Model property.
        /// </summary>
        void Initialize();
    }
}
