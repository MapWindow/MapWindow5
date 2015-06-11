// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGisToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The GisToolView interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views
{
    #region

    using System.Collections.Generic;

    using MW5.Plugins.Mvp;
    using MW5.Tools.Model;
    using MW5.Tools.Model.Parameters;

    #endregion

    /// <summary>
    /// The GisToolView interface.
    /// </summary>
    public interface IGisToolView : IView<GisToolBase>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Generate the controls.
        /// </summary>
        /// <param name="requiredParameters">The required parameters</param>
        /// <param name="optionalParameters">The optional parameters</param>
        void GenerateControls(IEnumerable<BaseParameter> requiredParameters, IEnumerable<BaseParameter> optionalParameters);

        #endregion
    }
}