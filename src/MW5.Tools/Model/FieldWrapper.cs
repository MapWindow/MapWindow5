using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    public class FieldWrapper
    {
        public FieldWrapper(string layerName, string fieldName)
        {
            LayerName = layerName;
            FieldName = fieldName;
        }

        public string LayerName { get; private set; }
        public string FieldName { get; private set; }
    }
}
