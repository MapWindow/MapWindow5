using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.TableEditor.utils;

namespace MW5.Plugins.TableEditor.BO
{
    /// <summary>
    ///  Class for handling the shapedata 
    /// </summary>
    public class ShapeData : ICallback
    {
        /// <summary>The shapefile-object</summary>
        private readonly Shapefile sf;

        /// <summary>Initializes a new instance of the BOShapeData class</summary>
        /// <param name = "shapeFile">The shapeFile.</param>
        public ShapeData(Shapefile shapeFile)
        {
            sf = shapeFile;
        }

        public int NumShapes
        {
            get { return sf.NumShapes; }
        }

        /// <summary>Check to see if dat has changed</summary>
        /// <param name = "dataTable">The datatable with data.</param>
        /// <returns>The result</returns>
        public bool DataChanged(DataTable dataTable)
        {
            var dataChanged = false;

            if ((dataTable.Columns.Count - 1) != sf.NumFields)
            {
                dataChanged = true;
            }

            for (var i = 1; i <= sf.NumFields; i++)
            {
                if (dataTable.Columns[i].ColumnName != sf.get_Field(i - 1).Name)
                {
                    dataChanged = true;
                }

                if ((bool) dataTable.Columns[i].ExtendedProperties["removed"])
                {
                    dataChanged = true;
                }
            }

            if (dataTable.GetChanges() != null)
            {
                dataChanged = true;
            }

            return dataChanged;
        }

        /// <summary>Get the shapefile data as a datatable</summary>
        /// <param name="amount">The max number of rows to retrieve</param>
        /// <returns>The datatable with shapefiledata</returns>
        public DataTable GetDataTable(int amount)
        {
            var dt = CreateTable();

            var numShapes = sf.NumShapes;
            var numfields = sf.NumFields;

            // PM, 9 Oct 2012: Added:
            dt.BeginLoadData();

            for (var j = 0; j < numShapes; j++)
            {
                var dr = dt.NewRow();

                for (var i = 0; i < numfields; i++)
                {
                    if (i == 44)
                    {
                        Debug.WriteLine("Starting");
                    }

                    // PM, 9 Oct 2012: Added to prevent errors about null values (Issue #2223):
                    dr[i + 1] = sf.get_CellValue(i, j) ?? DBNull.Value;
                }

                dt.Rows.Add(dr);

                if (j%100 == 0)
                {
                    // TODO: Add progress bar
                    Application.DoEvents();
                }

                if (j == amount)
                {
                    break;
                }
            }

            // PM, 9 Oct 2012: Added:
            dt.EndLoadData();

            dt.AcceptChanges();
            return dt;
        }

        /// <summary>Save data to shapefile</summary>
        /// <param name = "dataTable">The datatable with data.</param>
        public void SaveData(DataTable dataTable)
        {
            if (!sf.StartEditingTable(null))
            {
                MessageBox.Show(string.Format("Error in StartEditingTable: {0}", sf.get_ErrorMsg(sf.LastErrorCode)));
            }

            AddField(dataTable);

            ChangeData(dataTable);

            ChangeFieldNames(dataTable);

            DeleteField(dataTable);

            // To restore the join after saving:
            sf.Table.OnUpdateJoin += Table_OnUpdateJoin;

            if (!sf.StopEditingTable(true, this))
            {
                MessageBox.Show(string.Format("Error in StopEditingTable: {0}", sf.get_ErrorMsg(sf.LastErrorCode)));
            }
            else
            {
                dataTable.AcceptChanges();

                // PM 17 Jan 2013 (Issue #2268): Refresh categories:
                sf.Categories.ApplyExpressions();
            }
        }

        /// <summary>
        /// Restores join on loading or after saving
        /// </summary>
        /// <param name="filename">Filename of the datasource to join</param>
        /// <param name="fieldList">Csv list of fields</param>
        /// <param name="joinOptions">Provider specific options</param>
        /// <param name="joinSource">At table to be filled to data source and passed to the ocx</param>
        public static void Table_OnUpdateJoin(string filename, string fieldList, string joinOptions, Table joinSource)
        {
            DataTable dt;

            filename = filename.ToLower();
            if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
            {
                dt = XLSImport.GetData(filename, getOption("workbook", joinOptions));
            }
            else if (filename.EndsWith(".csv"))
            {
                dt = CSVImport.GetData(filename, getOption("separator", joinOptions));
            }
            else
            {
                return;
            }

            DbfImport.FillMapWinGisTable(dt, joinSource);
        }

        /// <summary>
        /// Returns a single join option from the string "name=value;name2=value2;etc.."
        /// </summary>
        /// <param name="name">The name of the options</param>
        /// <param name="joinOptions">Initial string with join options</param>
        /// <returns>The value of the option</returns>
        private static String getOption(String name, String joinOptions)
        {
            var options = joinOptions.Split(';');
            foreach (var s in options)
            {
                var parts = s.Split('=');
                if (parts[0] != null && parts.Length == 2 && parts[0].ToLower() == name)
                {
                    return parts[1];
                }
            }
            return "";
        }

        /// <summary>Change the fieldnames in the shapefile</summary>
        /// <param name = "dataTable">The datatable with data.</param>
        private void ChangeFieldNames(DataTable dataTable)
        {
            for (var i = 1; i < dataTable.Columns.Count; i++)
            {
                var field = sf.get_Field(i - 1);

                if (dataTable.Columns[i].ColumnName != field.Name)
                {
                    field.Name = dataTable.Columns[i].ColumnName;
                    sf.Table.EditReplaceField(i - 1, field, null);
                }
            }
        }

        /// <summary>Changes the data in the shapefile</summary>
        /// <param name = "dataTable">The datatable with data.</param>
        private void ChangeData(DataTable dataTable)
        {
            var datatChangedData = dataTable.GetChanges();

            if (datatChangedData != null)
            {
                for (var i = 0; i < datatChangedData.Rows.Count; i++)
                {
                    for (var j = 0; j < sf.NumFields; j++)
                    {
                        var shapeId = Convert.ToInt32(datatChangedData.Rows[i][0]);
                        if (!sf.EditCellValue(j, shapeId, datatChangedData.Rows[i][j + 1]))
                        {
                            MessageBox.Show(string.Format("Error in EditCellValue: {0}",
                                sf.get_ErrorMsg(sf.LastErrorCode)));
                        }
                    }
                }
            }
        }

        /// <summary>Add fields to shapefile</summary>
        /// <param name = "dataTable">The datatable with data.</param>
        private void AddField(DataTable dataTable)
        {
            for (var newCol = sf.NumFields + 1; newCol < dataTable.Columns.Count; newCol++)
            {
                var column = dataTable.Columns[newCol];
                AddField(column);
            }
        }

        /// <summary>Delete fields from shapefile</summary>
        /// <param name = "dataTable">The datatable with data.</param>
        private void DeleteField(DataTable dataTable)
        {
            for (var col = dataTable.Columns.Count - 1; col > 0; col--)
            {
                if ((bool) dataTable.Columns[col].ExtendedProperties["removed"])
                {
                    sf.EditDeleteField(col - 1, null);
                }
            }
        }

        /// <summary>Add column to the datatable</summary>
        /// <param name = "dt">The datatable to add the column to.</param>
        /// <param name = "fieldName">The name of the new column.</param>
        /// <param name = "fieldType">The type of the new column.</param>
        /// <param name = "precision">The precision of the new column.</param>
        /// <param name = "width">The width of the new column.</param>
        public static void AddDataColumn(DataTable dt, string fieldName, string fieldType, string precision, int width)
        {
            var dataColumn = new DataColumn
            {
                ColumnName = fieldName,
                DataType = GetFieldType(fieldType)
            };
            dataColumn.ExtendedProperties.Add("removed", false);

            if (dataColumn.DataType == typeof (double))
            {
                dataColumn.ExtendedProperties.Add("precision", precision);
            }

            if (dataColumn.DataType == typeof (string))
            {
                dataColumn.MaxLength = width;
            }
            else
            {
                dataColumn.ExtendedProperties.Add("width", width);
            }

            dt.Columns.Add(dataColumn);
        }

        /// <summary>Get a list of fieldnames that are visible</summary>
        /// <param name = "dt">The datatable.</param>
        /// <returns>List of fieldnames</returns>
        public static string[] GetVisibleFieldNames(DataTable dt)
        {
            var names = new List<string>();

            for (var i = 1; i < dt.Columns.Count; i++)
            {
                var dc = dt.Columns[i];

                if (!(bool) dt.Columns[i].ExtendedProperties["removed"])
                {
                    names.Add(dt.Columns[i].ColumnName);
                }
            }

            return names.ToArray();
        }

        /// <summary>Add a field to the shapefile</summary>
        /// <param name = "column">The column to add.</param>
        public void AddField(DataColumn column)
        {
            var name = column.ColumnName;
            var fieldType = GetMapWindowFieldType(column.DataType);
            var precision = GetPrecision(column);
            var width = GetWidth(column);

            var fieldIndexNew = sf.EditAddField(name, fieldType, precision, width);
        }

        /// <summary>Checks if a given fieldname is valid</summary>
        /// <param name = "fieldName">The given fieldname.</param>
        /// <param name = "dt">The datatable.</param>
        /// <param name = "message">A message which can be returned to the calling function.</param>
        /// <returns>The result</returns>
        public static bool IsNameValid(string fieldName, DataTable dt, ref string message)
        {
            var isValid = true;

            if (fieldName == string.Empty)
            {
                message = "Please enter a name.";
                isValid = false;
            }

            if (fieldName.Length > 10)
            {
                message = "Max fieldlength is 10.";
                isValid = false;
            }

            foreach (DataColumn dataColumn in dt.Columns)
            {
                if (dataColumn.ColumnName.ToUpper() == fieldName.ToUpper())
                {
                    message =
                        "Fieldname already exists or has been previously added/removed in this session. Apply or cancel your changes and try again.";
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>Get the width of a column</summary>
        /// <param name = "column">The column.</param>
        /// <returns>The width</returns>
        private int GetWidth(DataColumn column)
        {
            int width;
            if (column.DataType == typeof (string))
            {
                width = column.MaxLength;
            }
            else
            {
                width = (int) column.ExtendedProperties["width"];
            }

            return width;
        }

        /// <summary>Get the precision of a column</summary>
        /// <param name = "column">The column.</param>
        /// <returns>The precision</returns>
        private int GetPrecision(DataColumn column)
        {
            var precision = 0;

            if (column.DataType == typeof (double))
            {
                precision = Convert.ToInt32(column.ExtendedProperties["precision"]);
            }

            return precision;
        }

        /// <summary>Create a datatable based on the shapefile</summary>
        /// <returns>The datatable</returns>
        private DataTable CreateTable()
        {
            var dataTable = new DataTable();

            var dataColumn = new DataColumn
            {DataType = typeof (int), ColumnName = "SHAPE__ID", AutoIncrement = true, Unique = true};

            dataTable.Columns.Add(dataColumn);

            for (var i = 0; i < sf.NumFields; i++)
            {
                dataColumn = new DataColumn();

                var field = sf.get_Field(i);

                // No need to change the name, because it isn't stored in the dbf and don't have to comply with the 10 characters length rule:
                dataColumn.ColumnName = sf.Table.get_FieldIsJoined(i)
                    ? field.Name
                    : GetValidFieldName(field.Name, dataTable);

                dataColumn.DataType = GetFieldType(field.Type);
                dataColumn.ExtendedProperties.Add("removed", false);
                dataColumn.ExtendedProperties.Add("joined", sf.Table.get_FieldIsJoined(i));
                dataColumn.ReadOnly = sf.Table.get_FieldIsJoined(i);
                dataTable.Columns.Add(dataColumn);
            }

            return dataTable;
        }

        /// <summary>Get a valid fieldname</summary>
        /// <param name = "fieldName">The fieldName.</param>
        /// <param name = "dataTable">The dataTable.</param>
        /// <returns>The valid fieldName</returns>
        private string GetValidFieldName(string fieldName, DataTable dataTable)
        {
            var displayName = string.Empty;

            var errorMessage = string.Empty;
            var isValid = IsNameValid(fieldName, dataTable, ref errorMessage);
            if (!isValid)
            {
                displayName = GenerateNewFieldName(fieldName, dataTable);
            }
            else
            {
                displayName = fieldName;
            }

            return displayName;
        }

        /// <summary>Generate a valid fieldname</summary>
        /// <param name = "fieldName">The fieldName.</param>
        /// <param name = "dataTable">The dataTable.</param>
        /// <returns>The generated fieldName</returns>
        private string GenerateNewFieldName(string fieldName, DataTable dataTable)
        {
            var isValid = false;
            var newName = string.Empty;

            if (fieldName.Length > 9)
            {
                fieldName = fieldName.Substring(0, 9);
            }

            for (var number = 1; number < 10; number++)
            {
                newName = string.Format("{0}{1}", fieldName, number);

                var errorMessage = string.Empty;
                if (IsNameValid(newName, dataTable, ref errorMessage))
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                newName = Guid.NewGuid().ToString().Substring(0, 10);
                MessageBox.Show(string.Format("Field {0} will shown as {1}", fieldName, newName));
            }

            return newName;
        }

        /// <summary>Get the fieldtype</summary>
        /// <param name = "fieldType">The fieldType as string.</param>
        /// <returns>The fieldType as Type</returns>
        private static Type GetFieldType(string fieldType)
        {
            Type type = null;

            switch (fieldType)
            {
                case "Double":
                    type = typeof (double);
                    break;
                case "Integer":
                    type = typeof (int);
                    break;
                case "String":
                    type = typeof (string);
                    break;
                default:
                    // Default to string
                    type = typeof (string);
                    break;
            }

            return type;
        }

        /// <summary>Get the fieldtype</summary>
        /// <param name = "fieldType">The fieldType as fieldType.</param>
        /// <returns>The fieldType as Type</returns>
        private Type GetFieldType(FieldType fieldType)
        {
            Type type = null;

            switch (fieldType)
            {
                case FieldType.DOUBLE_FIELD:
                    type = typeof (double);
                    break;
                case FieldType.INTEGER_FIELD:
                    type = typeof (int);
                    break;
                case FieldType.STRING_FIELD:
                    type = typeof (string);
                    break;
                default:
                    // Default to string
                    type = typeof (string);
                    break;
            }

            return type;
        }

        /// <summary>Get the MapwIndow-Type</summary>
        /// <param name = "fieldType">The fieldType as Type.</param>
        /// <returns>The fieldType as MapwIndow-Type</returns>
        private FieldType GetMapWindowFieldType(Type fieldType)
        {
            // Default string
            var type = FieldType.STRING_FIELD;

            if (fieldType == typeof (double))
            {
                type = FieldType.DOUBLE_FIELD;
            }
            else if (fieldType == typeof (int))
            {
                type = FieldType.INTEGER_FIELD;
            }

            return type;
        }

        #region ICallback Members

        /// <summary>Show Error</summary>
        /// <param name = "KeyOfSender">The key of sender.</param>
        /// <param name = "ErrorMsg">The errorMessage.</param>
        public void Error(string KeyOfSender, string ErrorMsg)
        {
            MessageBox.Show("Error: " + ErrorMsg);
        }

        /// <summary>Show progress</summary>
        /// <param name = "KeyOfSender">The key of sender.</param>
        /// <param name = "Percent">The percentage.</param>
        /// <param name = "Message">The message.</param>
        public void Progress(string KeyOfSender, int Percent, string Message)
        {
            if (string.IsNullOrEmpty(Message))
            {
                //MapWinUtility.Logger.Progress(Percent, 100);
            }
        }

        #endregion
    }
}