using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    public abstract class NumericParameter<T> : BaseParameter, ISupportsValidation
        where T : IComparable<T>, IFormattable
    {
        public T MinValue { get; set; }

        public T MaxValue { get; set; }

        public bool HasRange { get; set; }

        public bool Validate(out string errorMessage)
        {
            if (HasRange)
            {
                errorMessage = DisplayName + string.Format(": value of the parameter outside range [{0}; {1}]", MinValue, MaxValue);
                var val = (T)Value;
                return val.CompareTo(MinValue) != -1 && val.CompareTo(MaxValue) != 1;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
