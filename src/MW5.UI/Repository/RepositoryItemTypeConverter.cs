using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Helpers;
using MW5.UI.Helpers;

namespace MW5.UI.Repository
{
    public class RepositoryItemTypeConverter : IEnumConverter<RepositoryItemType>
    {
        public string GetString(RepositoryItemType value)
        {
            switch (value)
            {
                case RepositoryItemType.FileSystem:
                    return "File System";
                case RepositoryItemType.Folder:
                    return "Folder";
                case RepositoryItemType.Vector:
                    return "Vector layer";
                case RepositoryItemType.Databases:
                    return "Spatial Databases";
                case RepositoryItemType.PostGis:
                    return "PostGIS";
                case RepositoryItemType.Database:
                    return "Database";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }
    }
}
