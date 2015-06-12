// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GisToolBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The gis tool base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    #region

    using System.Collections.Generic;

    using MW5.Plugins.Interfaces;
    using MW5.Tools.Model.Parameters;

    #endregion

    /// <summary>
    /// The gis tool base.
    /// </summary>
    public abstract class GisToolBase
    {
        #region Fields

        /// <summary>
        /// The parameters.
        /// </summary>
        protected List<BaseParameter> Parameters = new List<BaseParameter>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="context">The context.</param>
        public abstract void Initialize(IAppContext context);

        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool Run();

        #endregion
    }
}