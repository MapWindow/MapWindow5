// ********************************************************************************************************
// <copyright file="DbfImport.cs" company="TopX Geo-ICT">
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
// Date           Changed By           Notes
// 11 June 2012   Jeen de Vegt         Inital coding
// 31 May 2013    Paul Meems           Made the source code Style-cop compliant
// ********************************************************************************************************

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