using System.Collections.Generic;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface IProjectionDatabase
    {
        /// <summary>
        /// Gets coordinate system by EPSG code
        /// </summary>
        /// <param name="epsgCode">EPSG code of the projection</param>
        ICoordinateSystem GetCoordinateSystem(int epsgCode);

        /// <summary>
        /// Gets coordinate system from database for specified projection string. Any projection format can be used.
        /// </summary>
        ICoordinateSystem GetCoordinateSystem(string str, ProjectionSearchType searchType);

        /// <summary>
        /// Returns coordinate system object associated with given GeoProjection.
        /// This property is computationally expensive.
        /// </summary>
        ICoordinateSystem GetCoordinateSystem(ISpatialReference projection, ProjectionSearchType searchType);

        /// <summary>
        /// Gets databass name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        List<IRegion> Regions { get; }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        List<ICountry> Countries { get; }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        List<IGeographicCs> GeographicCs { get; }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        List<IProjectedCs> ProjectedCs { get; }

        /// <summary>
        /// Gets the unified list of geographical and projected ccordinate systems
        /// </summary>
        IEnumerable<ICoordinateSystem> CoordinateSystems { get; }

        /// <summary>
        /// Save dialects to the database
        /// </summary>
        void SaveDialects(ICoordinateSystem cs);

        /// <summary>
        /// Reads dialects for a given coordinate system
        /// </summary>
        void ReadDialects(ICoordinateSystem cs);

        /// <summary>
        /// Refreshes the dictionary with the complete list of dialects. Should be called a single time before EpsgCodeByDialectString call.
        /// </summary>
        void RefreshDialects();

        /// <summary>
        /// Returns code that correspnds to the given dialect string
        /// </summary>
        /// <param name="proj">Projection string in either proj4 or WKT format</param>
        /// <returns>EPSG code</returns>
        int EpsgCodeByDialectString(string proj);

        /// <summary>
        /// Returns code that correspnds to the given dialect string
        /// </summary>
        /// <param name="proj">Projection object; WKT, proj4 formats will be tested</param>
        /// <returns>EPSG code</returns>
        int EpsgCodeByDialectString(ISpatialReference proj);

        /// <summary>
        /// Reads the database
        /// </summary>
        /// <param name="executablePath">The path to MapWindow.exe</param>
        /// <returns></returns>
        bool ReadFromExecutablePath(string executablePath);

        /// <summary>
        /// Queries database and fill the list of GCS
        /// There are 4 levels in hierarchy: Regions->Countries->GCS->PCS
        /// The linking inforation:
        /// Regions->Countries (Countries.REGION_CODE on Region.REGION_cODE)
        /// Regions->GCS (mwGCSByRegion)
        /// Countries->GCS (mwGCSByCountry)
        /// GCS->PCS (PCS.SOUCRCE_CODE on GCS.CODE)
        /// </summary>
        bool Read(string dbName);

        /// <summary>
        /// Utility function to fill one of the tables fo modified EPSG database
        /// </summary>
        /// <param name="dbName">The filename of database to work with</param>
        void FillCountryByArea(string dbName);

        /// <summary>
        /// Updates proj4 strings in the proj4 column of coordinate reference systems table
        /// Assumes that there is Coordinate Reference System table in the database (was removed from Sqlite).
        /// </summary>
        /// <returns></returns>
        void UpdateProj4Strings(string dbName);
    }
}
