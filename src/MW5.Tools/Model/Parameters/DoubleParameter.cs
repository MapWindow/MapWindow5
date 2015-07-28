// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The double parameter.
    /// </summary>
    public class DoubleParameter : NumericParameter<double>
    {
        public override bool Numeric
        {
            get { return true; }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:g3}", DisplayName, Value);
        }
    }
}