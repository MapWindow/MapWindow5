// -------------------------------------------------------------------------------------------
// <copyright file="IGisToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The GisToolView interface.
    /// </summary>
    public interface IGisToolView : IView<GisToolBase>
    {
        /// <summary>
        /// Generate the controls.
        /// </summary>
        /// <param name="parameters">The parameters</param>
        void GenerateControls(IEnumerable<BaseParameter> parameters);
    }
}