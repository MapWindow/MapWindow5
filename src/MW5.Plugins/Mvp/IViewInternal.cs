// -------------------------------------------------------------------------------------------
// <copyright file="IViewInternal.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    public interface IViewInternal
    {
        event Action OkClicked;

        ViewStyle Style { get; }

        bool Visible { get; }

        void BeforeClose();

        void Close();

        void ShowView(IWin32Window parent = null);

        void UpdateView();
    }

    public interface IViewInternal<TModel> : IViewInternal
    {
        TModel Model { get; }

        void InitInternal(TModel model);
    }
}