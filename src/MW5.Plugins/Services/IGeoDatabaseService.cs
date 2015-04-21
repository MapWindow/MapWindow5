using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Services
{
    public interface IGeoDatabaseService
    {
        void ImportLayer();
        DatabaseConnection PromptUserForConnection(GeoDatabaseType? databaseType = null);
    }
}
