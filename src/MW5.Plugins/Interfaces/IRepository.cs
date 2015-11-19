using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Model;

namespace MW5.Plugins.Interfaces
{
    public interface IRepository
    {
        IEnumerable<string> Folders { get; }
        IEnumerable<DatabaseConnection> Connections { get; }
        IEnumerable<WmsServer> WmsServers { get; }
        TmsProviderList TmsProviders { get;}
        IEnumerable<TmsProvider> DefaultTmsProviders { get; }

        void Initialize(IAppContext context);

        void AddFolderLink();
        void AddFolderLink(string path);
        void RemoveFolderLink(string path, bool silent);

        void AddConnectionWithPrompt(GeoDatabaseType? databaseType = null);
        void AddConnection(DatabaseConnection connection);
        void RemoveConnection(DatabaseConnection connection, bool silent);

        void AddWmsServer(WmsServer server);
        void RemoveWmsServer(WmsServer server);
        void UpdateWmsServer(WmsServer server);
        void ClearWmsServers();

        event EventHandler<FolderEventArgs> FolderAdded;
        event EventHandler<FolderEventArgs> FolderRemoved;
        event EventHandler<ConnectionEventArgs> ConnectionAdded;
        event EventHandler<ConnectionEventArgs> ConnectionRemoved;
    }
}
