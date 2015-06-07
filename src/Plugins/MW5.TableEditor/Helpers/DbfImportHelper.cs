using System.Data;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Helpers
{
    /// <summary>
    /// The dbf import.
    /// </summary>
    public static class DbfImportHelper
    {
        /// <summary>
        /// Fills table with data obtained by ADO.NET provider
        /// </summary>
        /// <param name="dt"> Data table to make the data from </param>
        /// <param name="tableToFill"> MapWinGIS table to copy the data to </param>
        public static void FillMapWinGisTable(DataTable dt, IAttributeTable tableToFill)
        {
            tableToFill.CreateNew(string.Empty);

            CopyFields(dt, tableToFill);

            CopyValues(dt, tableToFill);
        }

        private static void CopyValues(DataTable dt, IAttributeTable tableToFill)
        {
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
        }

        private static void CopyFields(DataTable dt, IAttributeTable tableToFill)
        {
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                var type = AttributeType.String;

                switch (dt.Columns[i].DataType.ToString())
                {
                    case "System.String":
                        type = AttributeType.String;
                        break;
                    case "System.Double":
                        type = AttributeType.Double;
                        break;
                    case "System.Int32":
                        type = AttributeType.Integer;
                        break;
                }

                var fld = new AttributeField
                {
                    Name = dt.Columns[i].ColumnName,
                    Type = type,
                    Precision = 6,
                };

                if (dt.Columns[i].MaxLength != -1)
                {
                    fld.Width = dt.Columns[i].MaxLength;
                }

                tableToFill.Fields.Add(fld);
            }
        }
    }
}