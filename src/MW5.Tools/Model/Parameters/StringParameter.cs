// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The string parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    #region

    using MW5.Tools.Views.Controls;

    #endregion

    /// <summary>
    /// The string parameter.
    /// </summary>
    public class StringParameter : BaseParameter
    {
        #region Public Properties

        /// <summary>
        /// Gets the default value.
        /// </summary>
        public string DefaultValue { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get
            {
                return Control.AsBase.GetValue() as string;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create control.
        /// </summary>
        /// <returns>
        /// The <see cref="ParameterControlBase"/>.
        /// </returns>
        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new StringParameterControl());
        }

        #endregion
    }
}