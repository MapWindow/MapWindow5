using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MW5.Plugins.TableEditor.utils
{
    /// <summary>
    /// The csv import.
    /// </summary>
    public class CSVImport
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get column names.
        /// </summary>
        /// <param name="filename">
        /// The filename.
        /// </param>
        /// <param name="delimiter">
        /// The delimiter.
        /// </param>
        /// <returns>A list of column names</returns>
        public static List<string> GetColumnNames(string filename, string delimiter)
        {
            string[] fields = null;
            string line;

            using (TextReader tr = new StreamReader(filename))
            {
                while (tr.Peek() != -1)
                {
                    line = tr.ReadLine();

                    if (line == string.Empty)
                    {
                        // Do nothing
                    }
                    else
                    {
                        // Get column-names
                        if (delimiter == "Tab")
                        {
                            if (line != null)
                            {
                                fields = line.Split('\t');
                            }
                        }
                        else
                        {
                            if (line != null)
                            {
                                // Issue #2275
                                // fields = line.Split(Convert.ToChar(delimiter));
                                fields = ParseLine(line, delimiter);
                            }
                        }

                        break;
                    }
                }
            }

            return fields != null ? fields.ToList() : null;
        }

        /// <summary>
        /// The get data.
        /// </summary>
        /// <param name="filename">
        /// The filename.
        /// </param>
        /// <param name="delimiter">
        /// The delimiter.
        /// </param>
        /// <returns>The datatable</returns>
        public static DataTable GetData(string filename, string delimiter)
        {
            string line;
            string[] fields = null;
            var columnNamesLine = true;
            var dt = new DataTable();

            using (TextReader tr = new StreamReader(filename))
            {
                while (tr.Peek() != -1)
                {
                    line = tr.ReadLine();

                    if (line == string.Empty)
                    {
                        // Do nothing
                        continue;
                    }

                    if (columnNamesLine)
                    {
                        if (delimiter == "Tab")
                        {
                            if (line != null)
                            {
                                fields = line.Split('\t');
                            }
                        }
                        else
                        {
                            if (line != null)
                            {
                                // Issue #2275:
                                // fields = line.Split(Convert.ToChar(delimiter));
                                fields = ParseLine(line, delimiter);
                            }
                        }

                        FormatValues(fields);

                        CreateTable(fields, dt);
                        columnNamesLine = false;
                    }
                    else
                    {
                        if (delimiter == "Tab")
                        {
                            if (line != null)
                            {
                                fields = line.Split('\t');
                            }
                        }
                        else
                        {
                            if (line != null)
                            {
                                // Issue #2275:
                                fields = ParseLine(line, delimiter);
                                // fields = line.Split(Convert.ToChar(delimiter));
                            }
                        }

                        FormatValues(fields);

                        // Check if row is valid
                        ConditionValues(fields, dt);

                        // Insert values into table
                        var dr = dt.NewRow();
                        if (fields != null)
                        {
                            if (dt.Columns.Count != fields.Length)
                            {
                                // Issue #2275:
                                //MapWinUtility.Logger.Message(
                                //  string.Format(
                                //    "The number of parsed data fields are not equal to the number of header fields.{0}Please adjust your data file.{0}Most likely you have the delimeter also in your data.{0}The table join does not yet respect double quotes around your data, e.g. {1}Charleston County Area, South Carolina{1}",
                                //    Environment.NewLine,
                                //    ((char)34)),
                                //  "Error joining CSV data",
                                //  MessageBoxButtons.OK,
                                //  MessageBoxIcon.Error,
                                //  MessageBoxDefaultButton.Button1);

                                // Some debugging:
                                var columnHeaders = GetColumnHeadersAsString(dt.Columns, true);
                                //MapWinUtility.Logger.Dbg("Columns:" + columnHeaders);
                                var fieldData = GetArrayAsString(fields, true);
                                //MapWinUtility.Logger.Dbg("Fields:" + fieldData);
                                return null;
                            }

                            for (var i = 0; i < fields.Length; i++)
                            {
                                dr[i] = fields[i];
                            }

                            dt.Rows.Add(dr);
                        }
                    }
                }
            }

            return dt;
        }

        /// <summary>Parses the line from the CSV file, using RegEx</summary>
        /// <param name="line">The line</param>
        /// <param name="delimiter">The delimiter</param>
        /// <returns>The data as a string array</returns>
        private static string[] ParseLine(string line, string delimiter)
        {
            var csvParser = new Regex(delimiter + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var fields = csvParser.Split(line);

            // clean up the fields (remove " and leading spaces)
            for (var i = 0; i < fields.Length; i++)
            {
                fields[i] = fields[i].TrimStart(' ', '"');
                fields[i] = fields[i].TrimEnd('"');
            }

            // For debugging:
            //MapWinUtility.Logger.Dbg("Fields:" + GetArrayAsString(fields, true));

            return fields;
        }

        /// <summary>Get the content of an array as string</summary>
        /// <param name="array">The array.</param>
        /// <param name="oneLine">String on 1 line or not</param>
        /// <returns>The array as a string</returns>
        private static string GetArrayAsString(IList<string> array, bool oneLine)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < array.Count; i++)
            {
                if (oneLine)
                {
                    sb.Append(string.Format("{0} | ", array[i]));
                }
                else
                {
                    sb.AppendLine(array[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>Get the column names as string</summary>
        /// <param name="dataColumnCollection">
        /// The data column collection.
        /// </param>
        /// <param name="oneLine">Column names one 1 line or not</param>
        /// <returns>The column names as string</returns>
        private static string GetColumnHeadersAsString(DataColumnCollection dataColumnCollection, bool oneLine)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < dataColumnCollection.Count; i++)
            {
                if (oneLine)
                {
                    sb.Append(string.Format("{0} | ", dataColumnCollection[i].ColumnName));
                }
                else
                {
                    sb.AppendLine(dataColumnCollection[i].ColumnName);
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check to make sure that something didn't get split by a comma when it shouldn't
        /// </summary>
        /// <param name="vals">
        /// The values of one line.
        /// </param>
        /// <param name="dt">
        /// The dt.
        /// </param>
        private static void ConditionValues(string[] vals, DataTable dt)
        {
            // Check to make sure that something didn't get split by a comma when it
            // shouldn't have... e.g., "Reston" and " VA" should have been "Reston, VA"
            // First Pass:
            if (vals.Length != dt.Columns.Count)
            {
                var unmatchedStarting = new ArrayList();
                var unmatchedEnding = new ArrayList();
                for (var i = 0; i < vals.Length - 1; i++)
                {
                    if (vals[i].StartsWith(((char) 34).ToString()) && !vals[i].EndsWith(((char) 34).ToString()))
                    {
                        unmatchedStarting.Add(i);
                    }
                    else if (vals[i].EndsWith(((char) 34).ToString()) && !vals[i].StartsWith(((char) 34).ToString()))
                    {
                        unmatchedEnding.Add(i);
                    }
                }

                if (unmatchedStarting.Count != unmatchedEnding.Count)
                {
                    ConditionValues_OneCommaOnly(vals); // Fallback -has some disadvantages
                }
                else
                {
                    var newVals = new ArrayList();
                    var append = string.Empty;
                    var appending = false;
                    for (var i = 0; i < vals.Length; i++)
                    {
                        if (!appending && !unmatchedStarting.Contains(i) && !unmatchedEnding.Contains(i))
                        {
                            newVals.Add(vals[i]);
                        }
                        else if (Convert.ToInt32(unmatchedEnding[0]) == i)
                        {
                            unmatchedStarting.RemoveAt(0);
                            unmatchedEnding.RemoveAt(0);
                            append += vals[i];
                            newVals.Add(append);
                            append = string.Empty;
                            appending = false;
                        }
                        else
                        {
                            appending = true;
                            append += vals[i] + ",";
                        }
                    }

                    vals = (string[]) newVals.ToArray(vals[0].GetType());
                }
            }

            for (var i = 0; i < vals.Length; i++)
            {
                vals[i] = vals[i].Trim();
                if ((vals[i].StartsWith(((char) 34).ToString()) && vals[i].EndsWith(((char) 34).ToString()))
                    || (vals[i].StartsWith("'") && vals[i].EndsWith("'")))
                {
                    vals[i] = vals[i].Substring(1, vals[i].Length - 2);
                }
            }
        }

        /// <summary>
        /// Check to make sure that something didn't get split by a comma when it shouldn't
        /// </summary>
        /// <param name="vals">
        /// The values of one line.
        /// </param>
        private static void ConditionValues_OneCommaOnly(string[] vals)
        {
            // Check to make sure that something didn't get split by a comma when it
            // shouldn't have... e.g., "Reston" and " VA" should have been "Reston, VA"
            for (var i = 0; i < vals.Length; i++)
            {
                vals[i] = vals[i].Trim();
            }

            var endCond = vals.Length - 2;
            for (var i = 0; i <= endCond; i++)
            {
                // If endcond changes, .NET seems to still cache the old endCond.
                // Helpful.
                if (i > endCond)
                {
                    break;
                }

                if (vals[i].StartsWith(((char) 34).ToString()) && !vals[i].EndsWith(((char) 34).ToString())
                    && !vals[i + 1].StartsWith(((char) 34).ToString()) && vals[i + 1].EndsWith(((char) 34).ToString()))
                {
                    // We probably have a problem here...
                    var newVals = new string[vals.Length - 2];

                    for (var q = 0; i <= vals.Length; i++)
                    {
                        // Reload, skipping item i and merging back in
                        if (q < i)
                        {
                            newVals[q] = vals[q];
                        }
                        else if (q == i)
                        {
                            newVals[q] = vals[q] + ", " + vals[q + 1];
                        }
                        else
                        {
                            newVals[q] = vals[q + 1];
                        }
                    }

                    // Update vals
                    vals = newVals;
                    endCond = vals.Length - 2;

                    // Reset i to rescan all
                    i = 0;
                }
            }

            for (var i = 0; i < vals.Length; i++)
            {
                if ((vals[i].StartsWith(((char) 34).ToString()) && vals[i].EndsWith(((char) 34).ToString()))
                    || (vals[i].StartsWith("'") && vals[i].EndsWith("'")))
                {
                    vals[i] = vals[i].Substring(1, vals[i].Length - 2);
                }
            }
        }

        /// <summary>
        /// Create the table to contain the csv
        /// </summary>
        /// <param name="fields">
        /// The fields.
        /// </param>
        /// <param name="dt">
        /// The dt.
        /// </param>
        private static void CreateTable(IEnumerable<string> fields, DataTable dt)
        {
            foreach (var col in
                fields.Select(a => new DataColumn {DataType = Type.GetType("System.String"), ColumnName = a}))
            {
                dt.Columns.Add(col);
            }

            var dr = dt.NewRow();
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                dr[i] = dt.Columns[i].ColumnName;
            }

            dt.Rows.Add(dr);
        }

        /// <summary>
        /// Format the values.
        /// </summary>
        /// <param name="fields">
        /// The fields.
        /// </param>
        private static void FormatValues(string[] fields)
        {
            for (var i = 0; i < fields.Length; i++)
            {
                fields[i] = fields[i].Trim();
                if ((fields[i].StartsWith(((char) 34).ToString()) && fields[i].EndsWith(((char) 34).ToString()))
                    || (fields[i].StartsWith("'") && fields[i].EndsWith("'")))
                {
                    fields[i] = fields[i].Substring(1, fields[i].Length - 2);
                }
            }
        }

        #endregion
    }
}