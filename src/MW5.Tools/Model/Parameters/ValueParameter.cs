using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Shared;

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
        public T DefaultValue
        {
            get
            {
                try
                {
                    var value = (T)_defaultValue;
                    return value;
                }
                catch
                {
                    _defaultValue = default(T);
                    Logger.Current.Warn("Invalid default value for property: " + Name);
                }

                return default(T);
            }
        }

        public T Value
        {
            get { return (T)Control.GetValue(); }
        }

        public override bool Validate(out string errorMessage)
        {
            errorMessage = string.Empty;
            return false;
        }
    }
}
