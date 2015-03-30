using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Projections.Services
{
    internal static class Constants
    {
        // names of columns in Regions table
        public const string CmnRegionCode = "Region_Code";
        public const string CmnRegionName = "Region_Name";
        public const string CmnRegionParent = "Parent_Region_Code";
        public const string CmnRegionIndex = "Index";

        // names of columns in Country table
        public const string CmnCountryCode = "Country_Code";
        public const string CmnCountryName = "Country_Name";
        public const string CmnCountryParent = "Region_Code";

        public const string CmnCountryXmin = "xMin";
        public const string CmnCountryXmax = "xMax";
        public const string CmnCountryYmin = "yMin";
        public const string CmnCountryYmax = "yMax";

        // names of columns for both GCS and PCS tables
        public const string CmnCsCode = "COORD_REF_SYS_CODE";
        public const string CmnCsName = "COORD_REF_SYS_NAME";
        public const string CmnCsAreaCode = "AREA_CODE";
        public const string CmnCsSouth = "AREA_SOUTH_BOUND_LAT";
        public const string CmnCsNorth = "AREA_NORTH_BOUND_LAT";
        public const string CmnCsLeft = "AREA_WEST_BOUND_LON";
        public const string CmnCsRight = "AREA_EAST_BOUND_LON";
        public const string CmnCsSource = "SOURCE_GEOGCRS_CODE";
        public const string CmnCsProjection = "PROJECTION_TYPE";
        public const string CmnCsScope = "CRS_SCOPE";
        public const string CmnCsLocal = "LOCAL";
        public const string CmnCsAreaName = "AREA_OF_USE";
        public const string CmnCsRemarks = "REMARKS";
        public const string CmnCsProj4 = "Proj4";

        // types of CS used
        public const string CsTypeGeographic_2D = "geographic 2D";
        public const string CsTypeGeographic_3D = "geographic 3D";
        public const string CsTypeProjected = "projected";

        // sql queries
        public const string SqlRegions = "SELECT * FROM [Countries] WHERE [Level] < 3"; //"SELECT * FROM [mwRegions] ORDER BY [Index]";
        public const string SqlCountries = "SELECT * FROM [Countries] WHERE [Level] = 3";
        public const string SqlGcs = "SELECT * FROM [Coordinate Systems] WHERE [COORD_REF_SYS_KIND] = " + "\"" + CsTypeGeographic_2D + "\"";
        public const string SqlPcs = "SELECT * FROM [Coordinate Systems] WHERE [COORD_REF_SYS_KIND] = " + "\"" + CsTypeProjected + "\"";
        public const string SqlCsByCountry = "SELECT * FROM [Country by Coordinate System] WHERE [REGION] = 0";
        public const string SqlGcsByRegion = "SELECT * FROM [Country by Coordinate System] WHERE [REGION] <> 0";

        public const int CodeAreaWorld = 1262;
    }
}
