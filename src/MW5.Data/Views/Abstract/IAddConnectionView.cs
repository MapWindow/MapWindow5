using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Data.Db;
using MW5.Data.Enums;
using MW5.Plugins.Enums;
using MW5.Plugins.Mvp;

namespace MW5.Data.Views.Abstract
{
    public interface IAddConnectionView: IView<AddConnectionModel>
    {
        string Name { get; }
        void Init(ConnectionBase info);
        ConnectionBase GetConnection();
        GeoDatabaseType DatabaseType { get; set; }
        void SetRawConnection(string cs);
        event Action TestConnection;
        event Action ConnectionChanged;
    }
}
