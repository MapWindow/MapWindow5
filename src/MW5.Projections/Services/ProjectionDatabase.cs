// EPSG Reference: a tool for visualization of EPSG coordinate system database
// Author: Sergei Leschinski

#define SQLITE_DATABASE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.DL;
using MW5.Shared;

namespace MW5.Projections.Services
{
    /// <summary>
    /// Encapsulates all the interaction with modified EPSG projections database
    /// </summary>
    public class ProjectionDatabase: IProjectionDatabase
    {
        // The filename of the database 
        private string _dbname = "";

        // return GCS structure by its code
        private readonly Hashtable _dctRegions = new Hashtable();
        private readonly Hashtable _dctCountries = new Hashtable();
        private readonly Hashtable _dctGcs = new Hashtable();
        private readonly Dictionary<string, int> _dialects = new Dictionary<string,int>();

        // list of geographic CS
        private List<IRegion> _listRegions = new List<IRegion>();
        private List<ICountry> _listCountries = new List<ICountry>();
        private List<IGeographicCs> _listGcs = new List<IGeographicCs>();
        private List<IProjectedCs> _listPcs = new List<IProjectedCs>();

        private readonly IDataProvider _provider;
        private bool _initialized = false;

        /// <summary>
        /// Constructor. Sets SqLite provider
        /// </summary>
        public ProjectionDatabase()
        {
            #if SQLITE_DATABASE
            _provider = new SqliteProvider();
            #else
            m_provider = new OleDbProvider();
            #endif
        }
        
        /// <summary>
        /// Creates a new instance of the EpsgDatabase class
        /// </summary>
        public bool Init(string databaseName)
        {
            if (_initialized)
            {
                return false;
            }

            if (!File.Exists(databaseName))
            {
                throw new FileNotFoundException("EPSG database wan't found: " + databaseName);
            }

            Read(databaseName);

            _initialized = true;
            return true;
        }

        #region Coordinate system searching
        /// <summary>
        /// Gets coordinate system by EPSG code
        /// </summary>
        /// <param name="epsgCode">EPSG code of the projection</param>
        public ICoordinateSystem GetCoordinateSystem(int epsgCode)
        {
            foreach (var gcs in _listGcs.Where(gcs => gcs.Code == epsgCode))
            {
                return gcs;
            }

            return _listPcs.FirstOrDefault(pcs => pcs.Code == epsgCode);
        }

        /// <summary>
        /// Gets coordinate system from database for specified projection string. Any projection format can be used.
        /// </summary>
        public ICoordinateSystem GetCoordinateSystem(string str, ProjectionSearchType searchType)
        {
            ICoordinateSystem cs = null;
            var proj = new SpatialReference();
            
            if (proj.ImportFromAutoDetect(str))
            {
                cs = GetCoordinateSystem(proj, searchType);
            }

            if (cs == null && proj.ImportFromEsri(str))
            {
                cs = GetCoordinateSystem(proj, searchType);
            }

            return cs;
        }
        
        /// <summary>
        /// Returns coordinate system object associated with given GeoProjection.
        /// This property is computationally expensive.
        /// </summary>
        public ICoordinateSystem GetCoordinateSystem(ISpatialReference projection, ProjectionSearchType searchType)
        {
            if (string.IsNullOrWhiteSpace(_dbname))
            {
                return null;
            }

            // standard
            var cs = GetCoordinateSystemCore(projection);
            if (searchType == ProjectionSearchType.Standard || cs != null)
            {
                return cs;
            }

            // enhanced
            var projTest = new SpatialReference();
            if (projTest.ImportFromProj4(projection.ExportToProj4()))
            {
                cs = GetCoordinateSystemCore(projection);
            }

            if (searchType == ProjectionSearchType.Enhanced || cs != null)
            {
                return cs;
            }

            // dialects
            RefreshDialects();
            int code = EpsgCodeByDialectString(projection);

            if (code != -1)
            {
                return GetCoordinateSystem(code);
            }

            return null;
        }

        /// <summary>
        /// Searches for the coordinate system
        /// </summary>
        private ICoordinateSystem GetCoordinateSystemCore(ISpatialReference proj)
        {
            string name = proj.Name.ToLower();

            if (proj.IsEmpty)
            {
                return null;
            }

            var projEsri = proj.MorphToEsri();
            string esriName = projEsri != null ? projEsri.Name.ToLower() : string.Empty;

            int epsg;
            if (proj.TryAutoDetectEpsg(out epsg))
            {
                return GetCoordinateSystem(epsg);
            }

            if (proj.IsGeographic)
            {
                return GetCoordinateSystemCore(_listGcs, name, esriName);
            }

            if (proj.IsProjected)
            {
                return GetCoordinateSystemCore(_listPcs, name, esriName);
            }

            return null;
        }

        private ICoordinateSystem GetCoordinateSystemCore(IEnumerable<ICoordinateSystem> list, string name, string esriName)
        {
            var cs = list.FirstOrDefault(item => item.Name.ToLower() == name);
            if (cs != null)
            {
                return cs;
            }

            if (!string.IsNullOrWhiteSpace(esriName))
            {
                return list.FirstOrDefault(item => item.EsriName.ToLower() == esriName);
            }

            return null;
        }
        #endregion

        #region Properties
        
        /// <summary>
        /// Gets databass name
        /// </summary>
        public string Name
        {
            get { return _dbname; }
        }
        
        /// <summary>
        /// Returns list of regions
        /// </summary>
        public List<IRegion> Regions
        {
            get { return _listRegions; }
        }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        public List<ICountry> Countries
        {
            get { return _listCountries; }
        }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        public List<IGeographicCs> GeographicCs
        {
            get { return _listGcs; }
        }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        public List<IProjectedCs> ProjectedCs
        {
            get { return _listPcs; }
        }

        /// <summary>
        /// Gets the unified list of geographical and projected ccordinate systems
        /// </summary>
        public IEnumerable<ICoordinateSystem> CoordinateSystems
        {
            get
            {
                return _listGcs.Union(_listPcs.Cast<ICoordinateSystem>());
            }
        }

        #endregion

        #region Dialects
        /// <summary>
        /// Save dialects to the database
        /// </summary>
        public void SaveDialects(ICoordinateSystem cs)
        {
            using (DbConnection conn = _provider.CreateConnection()) 
            {
                conn.ConnectionString = _provider.CreateConnectionString(_dbname);
                conn.Open();
                try
                {
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        // deleting recodrs
                        cmd.CommandText = "DELETE FROM [Dialects] WHERE Code = ?";
                        DbParameter param = _provider.CreateParameter();
                        param.Value = cs.Code;
                        cmd.Parameters.Add(param);
                        cmd.ExecuteNonQuery();

                        //cmd.Parameters.Add( new OleDbParameter("p1", cs.Code));

                        // inserting records
                        cmd.CommandText = "INSERT INTO [Dialects] VALUES(?, ?)";
                        cmd.Parameters.Add(_provider.CreateParameter());

                        //cmd.Parameters.Add(new OleDbParameter());
                        foreach (string s in cs.Dialects)
                        {
                            cmd.Parameters[1].Value = s.Trim();
                            cmd.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Reads dialects for a given coordinate system
        /// </summary>
        public void ReadDialects(ICoordinateSystem cs)
        {
            cs.Dialects.Clear();

            using (DbConnection conn = _provider.CreateConnection(_dbname))
            {
                conn.Open();
                try
                {
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        // deleting recodrs
                        cmd.CommandText = "SELECT [ProjString] FROM [Dialects] WHERE Code = ?";
                        DbParameter param = _provider.CreateParameter();
                        param.Value = cs.Code;
                        cmd.Parameters.Add(param);
                        DbDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                cs.Dialects.Add(reader.GetString(0));
                            }
                        }
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Current.Warn("Failed to read projection dialects: " + cs.Name, ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Refreshes the dictionary with the complete list of dialects. Should be called a single time before EpsgCodeByDialectString call.
        /// </summary>
        public void RefreshDialects()
        {
            _dialects.Clear();

            using (DbConnection conn = _provider.CreateConnection(_dbname))
            {
                conn.Open();
                try
                {
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        // deleting recodrs
                        cmd.CommandText = "SELECT * FROM [Dialects]";
                        DbDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _dialects.Add(reader.GetString(1), reader.GetInt32(0));
                            }
                        }
                        cmd.Dispose();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Returns code that correspnds to the given dialect string
        /// </summary>
        /// <param name="proj">Projection string in either proj4 or WKT format</param>
        /// <returns>EPSG code</returns>
        public int EpsgCodeByDialectString(string proj)
        {
            return _dialects.ContainsKey(proj) ? _dialects[proj] : -1;
        }

        /// <summary>
        /// Returns code that correspnds to the given dialect string
        /// </summary>
        /// <param name="proj">Projection object; WKT, proj4 formats will be tested</param>
        /// <returns>EPSG code</returns>
        public int EpsgCodeByDialectString(ISpatialReference proj)
        {
            var code = EpsgCodeByDialectString(proj.ExportToProj4());
            
            if (code == -1)
            {
                code = EpsgCodeByDialectString(proj.ExportToWkt());
            }

            if (code == -1)
            {
                code = EpsgCodeByDialectString(proj.ExportToEsri());
            }

            return code;
        }
        #endregion

        #region Reading
        /// <summary>
        /// Reads the database
        /// </summary>
        /// <param name="executablePath">The path to MapWindow.exe</param>
        /// <returns></returns>
        public bool ReadFromExecutablePath(string executablePath)
        {
            string path = Path.GetDirectoryName(executablePath) + @"\Projections\";
            if (!Directory.Exists(path))
            {
                MessageService.Current.Info("Projections folder isn't found: " + path);
                return false;
            }

            string extension = "";    
                    
            #if SQLITE_DATABASE
                extension = "*.db3";
            #else
                extension = "*.mdb";
            #endif

            string[] files = Directory.GetFiles(path, extension);
            if (files.Length != 1)
            {
                string msg = "A single database is expected. " + files.Length + " databases are found." +
                             Environment.NewLine + "Path : " + path + Environment.NewLine;

                MessageService.Current.Info(msg);
                return false;
            }
            return Read(files[0]);
        }
        
        /// <summary>
        /// Queries database and fill the list of GCS
        /// There are 4 levels in hierarchy: Regions->Countries->GCS->PCS
        /// The linking inforation:
        /// Regions->Countries (Countries.REGION_CODE on Region.REGION_cODE)
        /// Regions->GCS (mwGCSByRegion)
        /// Countries->GCS (mwGCSByCountry)
        /// GCS->PCS (PCS.SOUCRCE_CODE on GCS.CODE)
        /// </summary>
        public bool Read(string dbName)
        {
            _dbname = dbName;
            
            // regions
            _listRegions = new List<IRegion>(30);
            ReadRegions();

            // countries
            _listCountries = new List<ICountry>(300);
            ReadCountries();

            // geographic CS
            _listGcs = new List<IGeographicCs>(800);
            ReadGcs();

            // projected CS
            _listPcs = new List<IProjectedCs>(3000);
            ReadPcs();

            // linking regions and countries
            foreach (var country in _listCountries)
            {
                if (_dctRegions.ContainsKey(country.RegionCode))
                {
                    var region = (Region)_dctRegions[country.RegionCode];
                    region.Countries.Add(country);
                }
                else
                {
                    Logger.Current.Warn("Specified region wasn't found: " + country.RegionCode);
                }
            }

            // regional GCS
            LinkGcsToRegion();

            // linking GCS to country
            LinkGcsToCountry();

            // linking PCS to GCS
            foreach (var pcs in _listPcs)
            {
                if (_dctGcs.ContainsKey(pcs.SourceCode))
                {
                    var gcs = (GeographicCs)_dctGcs[pcs.SourceCode];
                    gcs.Projections.Add(pcs);
                }
                else
                {
                    Logger.Current.Debug("Source geographic CS for projected CS wasn't found: " + pcs.Code);
                }
            
            }

            // reading dialects
            RefreshDialects();
            
            return true;
        }

        /// <summary>
        /// Links geographic CS to countries
        /// </summary>
        private void LinkGcsToRegion()
        {
            DbConnection conn = _provider.CreateConnection(_dbname);
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = Constants.SqlGcsByRegion;
            conn.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int codeGcs = reader.GetInt32(1);
                    if (_dctGcs.ContainsKey(codeGcs))
                    {
                        var gcs = (GeographicCs)_dctGcs[codeGcs];
                        gcs.Type = GeographicalCsType.Regional;
                        gcs.RegionCode = reader.GetInt32(0); ;
                    }
                }
            }
        }

        /// <summary>
        /// Links geographic CS to countries
        /// </summary>
        private void LinkGcsToCountry()
        {
            DbConnection conn = _provider.CreateConnection(_dbname);
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = Constants.SqlCsByCountry;

            conn.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int codeCountry = reader.GetInt32(0);
                    if (_dctCountries.ContainsKey(codeCountry))
                    {
                        Country country = (Country)_dctCountries[codeCountry];

                        string projType = reader.GetString(2);
                        if (projType == Constants.CsTypeGeographic_2D)
                        {
                            int codeGcs = reader.GetInt32(1);
                            if (_dctGcs.ContainsKey(codeGcs))
                            {
                                GeographicCs gcs = (GeographicCs)_dctGcs[codeGcs];
                                country.GeographicCs.Add(gcs);
                            }
                        }
                        else if (projType == Constants.CsTypeProjected)
                        {
                            int codePcs = reader.GetInt32(1);
                            country.ProjectedCs.Add(codePcs);
                        }
                    }
                }
            }

            // global CS which should be added for each country
            var listGlobalCs = _listGcs.Where(gcs => gcs.AreaCode == Constants.CodeAreaWorld).ToList();

            foreach (Country country in _listCountries)
            {
                foreach (var gcs in listGlobalCs)
                    country.GeographicCs.Add(gcs);
            }
        }

        /// <summary>
        /// Reads region from database and 
        /// </summary>
        /// <returns></returns>
        private bool ReadRegions()
        {
            _listRegions.Clear();

            DbConnection conn = _provider.CreateConnection(_dbname); // new DbConnection(get_ConectionString());
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = Constants.SqlRegions;

            conn.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            int codeColumn = ColumnIndexByName(reader, Constants.CmnCountryCode);
            int nameColumn = ColumnIndexByName(reader, Constants.CmnCountryName);
            int parentColumn = ColumnIndexByName(reader, Constants.CmnCountryParent);

            if (codeColumn == -1 || nameColumn == -1 || parentColumn == -1)
            {
                MessageService.Current.Warn("The expected field isn't found in the [Region] table.");
                return false;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Region region = new Region
                    {
                        Code = reader.GetInt32(codeColumn),
                        Name = reader.GetString(nameColumn),
                        ParentCode = reader.GetInt32(parentColumn)
                    };
                    _listRegions.Add(region);
                    _dctRegions.Add(region.Code, region);
                }
            }

            return true;
        }

        /// <summary>
        /// Returns index of the field by its name and -1 in case none field with such name exists
        /// </summary>
        private int ColumnIndexByName(DbDataReader reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (String.Equals(name, reader.GetName(i), StringComparison.CurrentCultureIgnoreCase))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Reading countries
        /// </summary>
        private bool ReadCountries()
        {
            _listCountries.Clear();

            DataTable dtCountries = get_Table(Constants.SqlCountries, false);
            if (dtCountries != null)
            {
                foreach (DataRow row in dtCountries.Rows)
                {
                    Country country = new Country
                    {
                        Code = (int) row[Constants.CmnCountryCode],
                        Name = (string) row[Constants.CmnCountryName],
                        RegionCode = (int) row[Constants.CmnCountryParent],
                        Left = ParseDouble(row[Constants.CmnCountryXmin]),
                        Right = ParseDouble(row[Constants.CmnCountryXmax]),
                        Bottom = ParseDouble(row[Constants.CmnCountryYmin]),
                        Top = ParseDouble(row[Constants.CmnCountryYmax])
                    };
                    _listCountries.Add(country);
                    _dctCountries.Add(country.Code, country);
                }
            }
            return true;
        }

        /// <summary>
        /// Reads list of geographic CS
        /// </summary>
        private bool ReadGcs()
        {
            DataTable dt = get_Table(Constants.SqlGcs, false);
            if (dt == null)
            {
                throw new Exception("mwGRS query wansn't found in the database: " + _dbname);
            }

            _listGcs.Clear();

            foreach (DataRow row in dt.Rows)
            {
                GeographicCs gcs = new GeographicCs
                {
                    Code = int.Parse(row[Constants.CmnCsCode].ToString()),
                    Name = row[Constants.CmnCsName].ToString(),
                    Left = ParseDouble(row[Constants.CmnCsLeft]),
                    Right = ParseDouble(row[Constants.CmnCsRight]),
                    Top = ParseDouble(row[Constants.CmnCsNorth]),
                    Bottom = ParseDouble(row[Constants.CmnCsSouth]),
                    AreaCode = int.Parse(row[Constants.CmnCsAreaCode].ToString()),
                    Scope = (row[Constants.CmnCsScope]).ToString(),
                    AreaName = (row[Constants.CmnCsAreaName]).ToString(),
                    Remarks = (row[Constants.CmnCsRemarks]).ToString(),
                    Proj4 = (row[Constants.CmnCsProj4]).ToString(),
                    EsriName = (row[Constants.EsriName]).ToString(),
                };

                // setting type of GCS
                gcs.Type = (gcs.Left != -180.0f || gcs.Bottom != -90.0f || gcs.Right != 180.0f || gcs.Top != 90.0f) ?
                            GeographicalCsType.Local : GeographicalCsType.Global;

                _listGcs.Add(gcs);

                // adding to hastable
                _dctGcs.Add(gcs.Code, gcs);
            }

            return true;
        }

        /// <summary>
        /// Reads list of Projected CS
        /// </summary>
        /// <returns></returns>
        private bool ReadPcs()
        {
            _listPcs.Clear();

            DbConnection conn = _provider.CreateConnection(_dbname); // new DbConnection(get_ConectionString());
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = Constants.SqlPcs;

            conn.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            int codeColumn = ColumnIndexByName(reader, Constants.CmnCsCode);
            int nameColumn = ColumnIndexByName(reader, Constants.CmnCsName);
            int sourceColumn = ColumnIndexByName(reader, Constants.CmnCsSource);
            int leftColumn = ColumnIndexByName(reader, Constants.CmnCsLeft);
            int rightColumn = ColumnIndexByName(reader, Constants.CmnCsRight);
            int bottomColumn = ColumnIndexByName(reader, Constants.CmnCsSouth);
            int topColumn = ColumnIndexByName(reader, Constants.CmnCsNorth);
            int areaNameColumn = ColumnIndexByName(reader, Constants.CmnCsAreaName);
            int remarksColumn = ColumnIndexByName(reader, Constants.CmnCsRemarks);
            int scopeColumn = ColumnIndexByName(reader, Constants.CmnCsScope);
            int typeColumn = ColumnIndexByName(reader, Constants.CmnCsProjection);
            int localColumn = ColumnIndexByName(reader, Constants.CmnCsLocal);
            int proj4Column = ColumnIndexByName(reader, Constants.CmnCsProj4);
            int esriNameColumn = ColumnIndexByName(reader, Constants.EsriName);

            if (codeColumn == -1 || nameColumn == -1 || sourceColumn == -1 ||
                leftColumn == -1 || rightColumn == -1 || bottomColumn == -1 ||
                topColumn == -1 || areaNameColumn == -1 || remarksColumn == -1 ||
                scopeColumn == -1 || typeColumn == -1 || localColumn == -1 || proj4Column == -1 ||
                esriNameColumn == -1 )
            {
                MessageService.Current.Warn("The expected field isn't found in the [Coordinate Systems] table");
                return false;
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var pcs = new ProjectedCs
                    {
                        Code = reader.GetInt32(codeColumn),
                        Name = reader.GetString(nameColumn),
                        Left = reader.GetDouble(leftColumn),
                        Right = reader.GetDouble(rightColumn),
                        Top = reader.GetDouble(topColumn),
                        Bottom = reader.GetDouble(bottomColumn),
                        SourceCode = reader.GetInt32(sourceColumn),
                        Scope = reader.GetString(scopeColumn),
                        AreaName = reader.GetString(areaNameColumn),
                        Proj4 = (!reader.IsDBNull(proj4Column)) ? reader.GetString(proj4Column) : "",
                        ProjectionType = (!reader.IsDBNull(typeColumn)) ? reader.GetString(typeColumn) : "",
                        Remarks = (!reader.IsDBNull(remarksColumn)) ? reader.GetString(remarksColumn) : "",
                        Local = false,
                        EsriName = (!reader.IsDBNull(esriNameColumn)) ? reader.GetString(esriNameColumn) : ""
                    };

                    if (!reader.IsDBNull(localColumn))
                    {
                        pcs.Local = reader.GetBoolean(localColumn);
                    }

                    _listPcs.Add(pcs);
                }
            }
            return true;
        }

        #endregion

        #region Utilities
        /// <summary>
        /// Parses double value.
        /// </summary>
        /// <param name="val"></param>
        /// <returns>0.0 on failure.</returns>
        private double ParseDouble(object val)
        {
            if (val == null)
            {
                return 0.0;
            }

            string s = val.ToString();
            return s != "" ? double.Parse(s) : 0.0;
        }

        /// <summary>
        /// Returns selected table form the database
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="tableDirect"></param>
        internal DataTable get_Table(string commandText, bool tableDirect)
        {
            DbDataAdapter adapter = _provider.CreateDataAdapter();
            DbConnection conn = _provider.CreateConnection(_dbname);

            try
            {
                DataTable dt = new DataTable();
                DbCommand cmd = conn.CreateCommand();

                cmd.CommandType = tableDirect ? CommandType.TableDirect : CommandType.Text;
                cmd.CommandText = commandText;

                adapter.SelectCommand = cmd;
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                Logger.Current.Error("Failed to open projection table: " + commandText, ex);
                return null;
            }
        }
        #endregion

        #region Fill country by area
        /// <summary>
        /// Utility function to fill one of the tables fo modified EPSG database
        /// </summary>
        /// <param name="dbName">The filename of database to work with</param>
        public void FillCountryByArea(string dbName)
        {
            DataSet ds = new DataSet();
            DbDataAdapter adapter = _provider.CreateDataAdapter();
            DbConnection conn = _provider.CreateConnection(_dbname);

            try
            {
                DataTable dtArea = new DataTable();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM [Area]";
                adapter.SelectCommand = cmd;
                adapter.Fill(dtArea);

                DataTable dtCoutries = new DataTable();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM [Countries] WHERE [Level] = 3";
                adapter.SelectCommand = cmd;
                adapter.Fill(dtCoutries);

                DataTable dtResults = new DataTable();
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "Country By Area";
                adapter.SelectCommand = cmd;
                adapter.Fill(dtResults);

                // CommandBuilder seems to be not clever enough to put brackets around the name of the table
                DbCommand cmdInsert = _provider.CreateCommand();
                cmdInsert.CommandText = "INSERT INTO [Country By Area] (AREA_CODE, COUNTRY_CODE) VALUES (@AREA_CODE, @COUNTRY_CODE)";
                cmdInsert.Connection = conn;

                // Add the parameters for the InsertCommand.
                DbParameter param = _provider.CreateParameter();
                param.ParameterName = "@AREA_CODE";
                param.DbType = DbType.Int32;
                param.Size = 10;
                param.SourceColumn = "AREA_CODE";
                cmdInsert.Parameters.Add(param);

                param = _provider.CreateParameter();
                param.ParameterName = "@COUNTRY_CODE";
                param.DbType = DbType.Int32;
                param.Size = 10;
                param.SourceColumn = "COUNTRY_CODE";
                cmdInsert.Parameters.Add(param);
                
                adapter.InsertCommand = cmdInsert;

                string[] list = new string[dtCoutries.Rows.Count];

                for (int i = 0; i < dtCoutries.Rows.Count; i++)
                {
                    string s = dtCoutries.Rows[i]["Alias"].ToString().ToLower();
                    list[i] = s;
                }

                int count = 0;

                for (int j = 0; j < list.Length; j++)
                {
                    string exclude = "";
                    if (list[j] == "niger") exclude = "nigeria";
                    if (list[j] == "oman") exclude = "romania";
                    if (list[j] == "mexico") exclude = "new mexico";
                    if (list[j] == "georgia") exclude = "usa";
                    if (list[j] == "georgia") exclude = "south georgia";
                    if (list[j] == "jersey") exclude = "new jersey";
                    if (list[j] == "india") exclude = "indiana";
                    if (list[j] == "antarctic") exclude = "australian";
                    if (list[j] == "canada") exclude = "canada plantation";
                    if (list[j] == "netherlands") exclude = "netherlands antilles";
                    if (list[j] == "china") exclude = "hong kong";
                    if (list[j] == "india") exclude = "bassas da india";
                    if (list[j] == "guinea") exclude = "papua new guinea";

                    for (int i = 0; i < dtArea.Rows.Count; i++)
                    {
                        string s = dtArea.Rows[i][2].ToString().ToLower();
                        if (s.Contains(list[j]))
                        {
                            if (exclude != "" && s.Contains(exclude))  // excluding unwanted coutries
                                continue;

                            DataRow row = dtResults.NewRow();
                            row[0] = dtArea.Rows[i][0];
                            row[1] = dtCoutries.Rows[j][0];
                            dtResults.Rows.Add(row);

                            count++;
                        }
                    }
                }

                adapter.Update(dtResults);
                MessageService.Current.Info(string.Format("Matches found: {0}", count));
            }
            finally
            {
                ds.Clear();
            }
        }
        #endregion

        #region UpdateProj4
        
        /// <summary>
        /// Updates proj4 strings in the proj4 column of coordinate reference systems table
        /// Assumes that there is Coordinate Reference System table in the database (was removed from Sqlite).
        /// </summary>
        /// <returns></returns>
        public void UpdateProj4Strings(string dbName)
        {
            var ds = new DataSet();
            DbDataAdapter adapter = _provider.CreateDataAdapter();
            DbConnection conn = _provider.CreateConnection(dbName);

            try
            {
                var dt = new DataTable();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [COORD_REF_SYS_CODE], [proj4] FROM [Coordinate Reference System]";
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);

                DbCommand cmdUpdate = conn.CreateCommand();
                cmdUpdate.CommandText = "UPDATE [Coordinate Reference System] SET proj4 = @proj4 WHERE COORD_REF_SYS_CODE = @cs";

                DbParameter param = _provider.CreateParameter();
                param.ParameterName = "@proj4";
                param.DbType = DbType.String;
                param.Size = 254;
                param.SourceColumn = "proj4";
                cmdUpdate.Parameters.Add(param);

                param = _provider.CreateParameter();
                param.ParameterName = "@cs";
                param.DbType = DbType.Int32;
                param.Size = 10;
                param.SourceColumn = "COORD_REF_SYS_CODE";
                cmdUpdate.Parameters.Add(param);
                
                adapter.UpdateCommand = cmdUpdate;

                int count = 0;
                ISpatialReference proj = new SpatialReference();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int code = (int)dt.Rows[i][0];
                    if (proj.ImportFromEpsg(code))
                    {
                        string proj4 = proj.ExportToProj4();
                        dt.Rows[i][1] = proj4;
                        count++;
                    }
                }

                adapter.Update(dt);
                MessageService.Current.Info(string.Format("Records updated: {0}", count));
            }
            finally
            {
                ds.Clear();
            }
        }

        public bool UpdateEsriName(string dbName)
        {
            int count = 0;

            try
            {
                using (DbDataAdapter adapter = _provider.CreateDataAdapter())
                {
                    using (DbConnection conn = _provider.CreateConnection(dbName))
                    {
                        var dt = new DataTable();
                        DbCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT [COORD_REF_SYS_CODE], [EsriName] FROM [Coordinate Systems]";
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dt);

                        DbCommand cmdUpdate = conn.CreateCommand();
                        cmdUpdate.CommandText =
                            "UPDATE [Coordinate Systems] SET EsriName = @esriName WHERE COORD_REF_SYS_CODE = @cs";

                        DbParameter param = _provider.CreateParameter();
                        param.ParameterName = "@esriName";
                        param.DbType = DbType.String;
                        param.Size = 100;
                        param.SourceColumn = "esriName";
                        cmdUpdate.Parameters.Add(param);

                        param = _provider.CreateParameter();
                        param.ParameterName = "@cs";
                        param.DbType = DbType.Int32;
                        param.Size = 10;
                        param.SourceColumn = "COORD_REF_SYS_CODE";
                        cmdUpdate.Parameters.Add(param);

                        adapter.UpdateCommand = cmdUpdate;

                        var proj = new SpatialReference();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var code = (int)dt.Rows[i][0];
                            if (proj.ImportFromEpsg(code))
                            {
                                var projEsri = proj.MorphToEsri();
                                if (projEsri != null)
                                {
                                    dt.Rows[i][1] = projEsri.Name;
                                    count++;
                                }
                            }
                        }

                        adapter.Update(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = "Failed to update ESRI name for registered coordinate systems.";
                Logger.Current.Error(msg, ex);
                MessageService.Current.Warn(msg + ": " + ex.Message);
                return false;
            }

            MessageService.Current.Info(string.Format("Records updated: {0}", count));
            return true;
        }

        #endregion
    }
}
