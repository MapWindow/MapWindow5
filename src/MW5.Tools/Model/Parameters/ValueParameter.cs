using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    public abstract class ValueParameter : BaseParameter
    {
        public virtual bool Numeric
        {
            get { return false; }
        }

        public abstract bool Validate(out string errorMessage);
    }

    public abstract class ValueParameter<T> : ValueParameter
    {
        public T DefaultValue { get; private set; }

        public T Value
        {
            get { return (T)Control.AsBase.GetValue(); }
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = string.Empty;
            return false;
        }
    }
}
