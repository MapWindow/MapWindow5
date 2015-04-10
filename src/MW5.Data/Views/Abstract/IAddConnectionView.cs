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
    public interface IAddConnectionView: IView
    {
        void Init(PostGisConnectionParams info);
        PostGisConnectionParams GetPostGisParams();
        event Action TestConnection;
        GeoDatabaseType DatabaseType { get; set; }
    }
}
