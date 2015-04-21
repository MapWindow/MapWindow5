using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Data.Enums
{
    public enum RepositoryItemType
    {
        FileSystem = 0,
        Folder = 1,
        Vector = 2,
        Databases = 3,
        Server = 4,
        Database = 5,
        Image = 6,
        DatabaseLayer = 7,
    }

    public enum RepositoryIcon
    {
        FileSystem = 0,
        Folder = 1,
        Point = 2,
        Line = 3,
        Polygon = 4,
        Geometry = 5,
        Databases = 6,
        Database = 7,
        PostGis = 8,
        Raster = 9,
        MsSql = 10,
        Sqlite = 11,
        Oracle = 12,
    }

    public enum FormatType
    {
        All = 0,
        Vector = 1,
        Raster = 2,
        Grid = 3,
    }
}
