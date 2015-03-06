using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Helpers
{
    public interface IEnumConverter<T> where T : struct, IConvertible
    {
        string GetString(T enumeration);
    }
}
