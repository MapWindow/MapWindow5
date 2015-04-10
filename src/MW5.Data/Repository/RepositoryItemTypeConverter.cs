using System;
using MW5.Api.Helpers;
using MW5.Shared;

namespace MW5.Data.Repository
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
