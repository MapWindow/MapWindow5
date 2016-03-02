// -------------------------------------------------------------------------------------------
// <copyright file="TileCacheHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Data.SQLite;
using System.IO;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Data.Helpers
{
    /// <summary>
    /// Helper methods to work with disk based tile cache.
    /// </summary>
    public static class TileCacheHelper
    {
        private static bool _initialized;

        /// <summary>
        /// Removes outdated tiles and vaccums database.
        /// </summary>
        public static void InitDatabase(string filename, TilesMaxAge maxAge)
        {
            Logger.Current.Debug("In TileCacheHelper.InitDatabase()");
            if (_initialized)
            {
                return;
            }

            if (File.Exists(filename))
            {
                if (DebugHelper.CleanTileCache)
                {
                    RemoveOutdatatedTiles(filename, maxAge);

                    Vacuum(filename);
                }

                _initialized = true;
            }
        }

        /// <summary>
        /// Validates the structure of tile cache database.
        /// </summary>
        public static bool ValidateDatabase(string filename)
        {
            try
            {
                using (var conn = new SQLiteConnection(string.Format(@"Data Source={0}", filename)))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "SELECT COUNT(*) from Tiles";
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Invalid tile cache database file.");
                Logger.Current.Debug("Exception in TileCacheHelper.ValidateDatabase: " + ex.Message);
            }

            return false;
        }

        private static string DateTimeSqLite(DateTime datetime)
        {
            const string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}";

            return string.Format(dateTimeFormat, datetime.Year, datetime.Month.ToString("d2"),
                datetime.Day.ToString("d2"), datetime.Hour.ToString("d2"), datetime.Minute.ToString("d2"),
                datetime.Second.ToString("d2"));
        }

        private static string GetSqliteStartDate(TilesMaxAge maxAge)
        {
            if (maxAge == TilesMaxAge.Never)
            {
                return string.Empty;
            }

            var date = GetStartDate(maxAge);
            if (date == default(DateTime))
            {
                return string.Empty;
            }

            return DateTimeSqLite(date);
        }

        private static DateTime GetStartDate(TilesMaxAge maxAge)
        {
            var span = default(TimeSpan);
            switch (maxAge)
            {
                case TilesMaxAge.Month:
                    span = new TimeSpan(-30, 0, 0, 0);
                    break;
                case TilesMaxAge.Month3:
                    span = new TimeSpan(-90, 0, 0, 0);
                    break;
                case TilesMaxAge.Month6:
                    span = new TimeSpan(-180, 0, 0, 0);
                    break;
                case TilesMaxAge.Year:
                    span = new TimeSpan(-365, 0, 0, 0);
                    break;
            }
            if (span == default(TimeSpan)) return default(DateTime);
            return DateTime.Now.Date.Add(span);
        }

        /// <summary>
        /// Removes outdated tiles from cache.
        /// </summary>
        private static void RemoveOutdatatedTiles(string filename, TilesMaxAge maxAge)
        {
            string date = GetSqliteStartDate(maxAge);
            if (string.IsNullOrWhiteSpace(date))
            {
                return;
            }

            try
            {
                using (var conn = new SQLiteConnection(string.Format(@"Data Source={0}", filename)))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = string.Format("DELETE FROM Tiles WHERE CacheTime < '{0}'", date);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to remove outdated tiles from cache.", ex);
            }
        }

        /// <summary>
        /// Decreases the size of SQLite tile cache database by releasing unoccupied space.
        /// </summary>
        private static void Vacuum(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            try
            {
                using (var conn = new SQLiteConnection(string.Format(@"Data Source={0}", filename)))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "vacuum;";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to vacuum tile cache database.", ex);
            }
        }
    }
}