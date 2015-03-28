using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace MW5.Plugins.TableEditor.Helpers
{
    /// <summary>
    ///   Takes care of importing data from excel
    /// </summary>
    public static class XlsImportHelper
    {
        /// <summary>Get a list of all the workbooks</summary>
        /// <param name = "fileName">The name of excel-file.</param>
        /// <returns>List of workbooks</returns>
        public static List<string> GetWorkbooks(string fileName)
        {
            var workBooks = new List<string>();

            var connectionString = GetConnectionString(fileName);

            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Get all of the Table names from the Excel workbook
                using (
                    var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"}))
                {
                    // Add the Table name to the combobox.
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        // Replace $ by "" 
                        workBooks.Add(dt.Rows[i]["TABLE_NAME"].ToString().Replace("$", string.Empty));
                    }

                    dt.Clear();
                }
            }

            return workBooks;
        }

        /// <summary>Get connectionstring to excel-file</summary>
        /// <param name = "fileName">The name of excel-file.</param>
        /// <returns>The connectionstring</returns>
        private static string GetConnectionString(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found.", fileName);
            }

            /*
            Where "HDR=Yes" means that there is a header row in the cell range 
            (or named range), so the connectionstring will not include the first row of the
            selection into the recordset. If "HDR=No", then the connectionstring will include
            the first row of the cell range (or named ranged) into the recordset.
            */
            if (fileName.ToLower().EndsWith(".xlsx"))
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                       "Data Source=" + fileName +
                       @";Extended Properties=""Excel 12.0;HDR=No;IMEX=1""";
            }
            return @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                   "Data Source=" + fileName +
                   @";Extended Properties=""Excel 8.0;HDR=No;IMEX=1""";
        }

        /// <summary>Get the columnnames</summary>
        /// <param name = "fileName">The name of excel-file.</param>
        /// <param name = "workBook">The name of the workbook.</param>
        /// <returns>A list of column-names</returns>
        public static List<string> GetColumnNames(string fileName, string workBook)
        {
            var colNames = new List<string>();

            var connectionString = GetConnectionString(fileName);

            if (connectionString == null)
            {
                throw new Exception("Error no connectionstring to file.");
            }

            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    var adapter = new OleDbDataAdapter(@"SELECT TOP 1 * FROM [" + workBook + "$]", conn);

                    var excelData = new DataTable();

                    adapter.Fill(excelData);

                    for (var i = 0; i < excelData.Columns.Count; i++)
                    {
                        colNames.Add(excelData.Rows[0][i].ToString());
                    }
                }
                catch (OleDbException oleDbEx)
                {
                    throw new Exception("OleDbException: " + oleDbEx.Message);
                }
            }

            return colNames;
        }

        /// <summary>Get the data from a workbook</summary>
        /// <param name = "fileName">The name of excel-file.</param>
        /// <param name = "workBook">The name of the workbook.</param>
        /// <returns>Data from the workbook</returns>
        public static DataTable GetData(string fileName, string workBook)
        {
            var excelData = new DataTable();

            var connectionString = GetConnectionString(fileName);

            if (connectionString == null)
            {
                throw new Exception("Error no connectionstring to file.");
            }

            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    var adapter = new OleDbDataAdapter(@"SELECT * FROM [" + workBook + "$]", conn);

                    adapter.Fill(excelData);

                    ChangeColumnNames(excelData);
                }
                catch (OleDbException oleDbEx)
                {
                    throw new Exception("OleDbException: " + oleDbEx.Message);
                }
            }

            return excelData;
        }

        /// <summary>Change the columnnames</summary>
        /// <param name = "excelData">A datatable with data.</param>
        private static void ChangeColumnNames(DataTable excelData)
        {
            for (var i = 0; i < excelData.Columns.Count; i++)
            {
                excelData.Columns[i].ColumnName = excelData.Rows[0][i].ToString();
            }
        }
    }
}