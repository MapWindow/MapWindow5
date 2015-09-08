using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    public abstract class NumericParameter : BaseParameter
    {
        public object MinValue { get; set; }

        public object MaxValue { get; set; }

        public bool HasRange { get; set; }

        public void SetRange(object min, object max)
        {
            MinValue = min;
            MaxValue = max;
            HasRange = true;
        }
    }

    public abstract class NumericParameter<T> : NumericParameter, ISupportsValidation
        where T : IComparable<T>, IFormattable
    {
        public bool Validate(out string errorMessage)
        {
            if (HasRange)
            {
                errorMessage = DisplayName + string.Format(": value of the parameter outside range [{0}; {1}]", MinValue, MaxValue);
                var val = (T)Value;
                return val.CompareTo((T)MinValue) != -1 && val.CompareTo((T)MaxValue) != 1;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
