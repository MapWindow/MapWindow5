// ********************************************************************************************************
// <copyright file="XLSImport.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// ********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace MW5.Plugins.TableEditor.utils
{
    /// <summary>
    ///   Takes care of importing data from excel
    /// </summary>
    public class XLSImport
    {
        /// <summary>Get a list of all the workbooks</summary>
        /// <param name = "fileName">The name of excel-file.</param>
        /// <returns>List of workbooks</returns>
        public static List<string> GetWorkbooks(string fileName)
        {
            List<string> workBooks = new List<string>();

            string connectionString = GetConnectionString(fileName);

            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Get all of the Table names from the Excel workbook
                using (var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" }))
                {
                    // Add the Table name to the combobox.
                    for (int i = 0; i < dt.Rows.Count; i++)
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
            else
            {
                return @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + fileName +
                @";Extended Properties=""Excel 8.0;HDR=No;IMEX=1""";
            }
        }

        /// <summary>Get the columnnames</summary>
        /// <param name = "fileName">The name of excel-file.</param>
        /// <param name = "workBook">The name of the workbook.</param>
        /// <returns>A list of column-names</returns>
        public static List<string> GetColumnNames(string fileName, string workBook)
        {
            List<string> colNames = new List<string>();

            string connectionString = GetConnectionString(fileName);

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

                    DataTable excelData = new DataTable();

                    adapter.Fill(excelData);

                    for (int i = 0; i < excelData.Columns.Count; i++)
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
            DataTable excelData = new DataTable();

            string connectionString = GetConnectionString(fileName);

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
            for (int i = 0; i < excelData.Columns.Count; i++)
            {
                excelData.Columns[i].ColumnName = excelData.Rows[0][i].ToString();
            }
        }
    }
}
