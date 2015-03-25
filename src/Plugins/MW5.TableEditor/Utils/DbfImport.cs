using System.Data;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.utils
{

    #region

    #endregion

    /// <summary>
    /// The dbf import.
    /// </summary>
    public class DbfImport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Fills table with data obtained by ADO.NET provider
        /// </summary>
        /// <param name="dt">
        /// Data table to make the data from
        /// </param>
        /// <param name="tableToFill">
        /// MapWinGIS table to copy the data to
        /// </param>
        /// <returns>True on success</returns>
        public static bool FillMapWinGisTable(DataTable dt, Table tableToFill)
        {
            if (dt == null)
            {
                return false;
            }

            tableToFill.CreateNew(string.Empty);
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                var type = FieldType.STRING_FIELD;
                switch (dt.Columns[i].DataType.ToString())
                {
                    case "System.String":
                        type = FieldType.STRING_FIELD;
                        break;
                    case "System.Double":
                        type = FieldType.DOUBLE_FIELD;
                        break;
                    case "System.Int32":
                        type = FieldType.INTEGER_FIELD;
                        break;
                }

                tableToFill.EditAddField(dt.Columns[i].ColumnName, type, 6, dt.Columns[i].MaxLength);
            }

            for (var j = 0; j < dt.Rows.Count; j++)
            {
                var index = tableToFill.NumRows;
                if (tableToFill.EditInsertRow(ref index))
                {
                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        tableToFill.EditCellValue(i, index, dt.Rows[j][i]);
                    }
                }
            }

            return true;
        }

        #endregion
    }
}