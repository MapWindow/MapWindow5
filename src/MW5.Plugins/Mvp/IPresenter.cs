// -------------------------------------------------------------------------------------------
// <copyright file="IPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    public interface IPresenter
    {
        /// <summary>
        /// Gets or sets the boolean value returned by Presenter.Run method.
        /// </summary>
        bool ReturnValue { get; }

        /// <summary>
        /// Gets the handler of the underlying window for the view.
        /// </summary>
        IWin32Window ViewHandle { get; }

        /// <summary>
        /// Runs the presenter by displaying the view associated with it.
        /// </summary>
        bool Run(IWin32Window parent = null);

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        bool ViewOkClicked();
    }

    /// <summary>
    /// Runs the presenter by displaying the view associated with it.
    /// </summary>
    public interface IPresenter<in TModel> : IPresenter
    {
        bool Run(TModel argument, IWin32Window parent = null);
    }
}