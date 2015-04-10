using System;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Events
{
    public class ConnectionEventArgs: EventArgs
    {
        public ConnectionEventArgs(DatabaseConnection connection)
        {
            Connection = connection;
        }

        public DatabaseConnection Connection { get; private set; }
    }
}
