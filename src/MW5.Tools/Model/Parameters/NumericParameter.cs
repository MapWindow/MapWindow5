using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model.Parameters
{
    public abstract class NumericParameter<T> : ValueParameter<T>
        where T : IComparable<T>, IFormattable
    {
        public T MinValue { get; set; }

        public T MaxValue { get; set; }

        public override bool Numeric { get { return true; } }

        public bool HasRange { get; set; }

        public override bool Validate(out string errorMessage)
        {
            if (HasRange)
            {
                errorMessage = DisplayName + string.Format(": value of the parameter outside range [{0}; {1}]", MinValue, MaxValue);
                return Value.CompareTo(MinValue) != -1 && Value.CompareTo(MaxValue) != 1;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
