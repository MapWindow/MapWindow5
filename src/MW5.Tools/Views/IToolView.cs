// -------------------------------------------------------------------------------------------
// <copyright file="IToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The ToolView interface.
    /// </summary>
    public interface IToolView : IView<ToolViewModel>
    {
        /// <summary>
        /// Generates the controls.
        /// </summary>
        void GenerateControls(IEnumerable<BaseParameter> parameters);

        bool RunInBackground { get; }
    }
}