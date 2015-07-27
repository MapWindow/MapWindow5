using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    public class OutputLayerParameter: BaseParameter
    {
        /// <summary>
        /// Gets a value indicating whether value.
        /// </summary>
        public OutputLayerInfo Value
        {
            get {  return Control.AsBase.GetValue() as OutputLayerInfo; }
        }
    }
}
