using System;
using MW5.Plugins.Enums;

namespace MW5.Tools.Model
{
    public class DataTypeHintAttribute: Attribute
    {
        public DataTypeHintAttribute(DataSourceType dataType)
        {
            DataType = dataType;
        }

        public DataSourceType DataType { get; private set; }
    }
}
