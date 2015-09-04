// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The double parameter.
    /// </summary>
    public class DoubleParameter : NumericParameter<double>
    {
        public override string ToString()
        {
            return string.Format("{0}: {1:g3}", DisplayName, Value);
        }
    }
}