using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Data.Db
{
    public interface IConnectionParams
    {
        string GetConnection();
        string BuildConnection();        // from parameters
        GeoDatabaseType DatabaseType { get; }
        string RawConnection { get; set; }
        bool IgnoreParams { get; set; }  // use raw connection instead
        string Name { get; }
        bool Validate();
    }
}
