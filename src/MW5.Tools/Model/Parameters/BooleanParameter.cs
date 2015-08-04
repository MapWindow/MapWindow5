// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The boolean parameter.
    /// </summary>
    public class BooleanParameter : ValueParameter<bool>
    {
        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Value);
        }
    }
}