using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;

namespace MW5.Data.Db
{
    internal class SpatiaLiteConnection: ConnectionBase
    {
        public string Filename { get; set; }

        public override string BuildConnection(bool noPassword = false)
        {
            return Filename;
        }

        public override GeoDatabaseType DatabaseType
        {
            get { return GeoDatabaseType.SpatiaLite; }
        }

        public override string Name
        {
            get
            {
                if (File.Exists(Filename))
                {
                    return Path.GetFileName(Filename);
                }

                return string.Empty;
            }
        }

        public override bool Validate()
        {
            if (!File.Exists(Filename))
            {
                MessageService.Current.Info("Filename doesn't exist: " + Filename);
                return false;
            }

            return true;
        }
    }
}
