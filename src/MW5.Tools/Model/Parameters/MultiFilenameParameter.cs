using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Tools.Model.Parameters
{
    internal class MultiFilenameParameter: BaseParameter, IInputParameter
    {
        private readonly DataSourceType _dataType;

        public MultiFilenameParameter(DataSourceType dataType)
        {
            _dataType = dataType;
        }

        public DataSourceType DataType
        {
            get { return _dataType; }
        }

        public object BatchInputs
        {
            get  { return null; }
        }

        public bool HasBatchInputs
        {
            get { return false; }
        }
    }
}
