// -------------------------------------------------------------------------------------------
// <copyright file="StringParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The string parameter.
    /// </summary>
    public class StringParameter : BaseParameter
    {
        /// <summary>
        /// Gets the default value.
        /// </summary>
        public string DefaultValue { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get { return Control.AsBase.GetValue() as string; }
        }
    }
}