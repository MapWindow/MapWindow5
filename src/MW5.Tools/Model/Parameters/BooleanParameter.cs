// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The boolean parameter.
    /// </summary>
    public class BooleanParameter : BaseParameter
    {
        /// <summary>
        /// Gets a value indicating whether default value.
        /// </summary>
        public bool DefaultValue { get; private set; }

        /// <summary>
        /// Gets a value indicating whether value.
        /// </summary>
        public bool Value
        {
            get { return (bool)Control.AsBase.GetValue(); }
        }

        /// <summary>
        /// The create control.
        /// </summary>
        public override ParameterControlBase CreateControl()
        {
            return Control ?? (Control = new BooleanParameterControl());
        }
    }
}