// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The boolean parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    #region

    using MW5.Tools.Views.Controls;

    #endregion

    /// <summary>
    /// The boolean parameter.
    /// </summary>
    public class BooleanParameter : BaseParameter
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether default value.
        /// </summary>
        public bool DefaultValue { get; private set; }

        /// <summary>
        /// Gets a value indicating whether value.
        /// </summary>
        public bool Value
        {
            get
            {
                return (bool)Control.AsBase.GetValue();
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
            return Control ?? (Control = new BooleanParameterControl());
        }

        #endregion
    }
}