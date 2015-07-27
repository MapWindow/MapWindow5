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
    public class StringParameter : ValueParameter<string>
    {
        public override bool Numeric
        {
            get { return false; }
        }
    }
}