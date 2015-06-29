// -------------------------------------------------------------------------------------------
// <copyright file="AttributeTableHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Attributes.Model;
using MW5.Shared;

namespace MW5.Attributes.Helpers
{
    public static class AttributeTableHelper
    {
        public static void CopyAttributes(this IAttributeTable table, int sourceIndex, int targetIndex)
        {
            table.CopyAttributes(sourceIndex, table, targetIndex);
        }

        public static void CopyAttributes(this IAttributeTable source, int sourceIndex, IAttributeTable target, int targetIndex)
        {
            var fields = source.Fields;
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Name.ToLower() == "mwshapeid")
                {
                    continue;
                }
                target.EditCellValue(i, targetIndex, source.CellValue(i, sourceIndex));
            }
        }

        public static void CopyAttributes(this IAttributeTable source, int sourceIndex, IAttributeTable target, int targetIndex, Dictionary<int, int> fieldMap)
        {
            if (fieldMap == null || target == null)
            {
                return;
            }

            var list = fieldMap.ToList();
            foreach (var fld in list)
            {
                object val = source.CellValue(fld.Key, sourceIndex);
                target.EditCellValue(fld.Value, targetIndex, val);
            }
        }

        public static Dictionary<int, int> BuildFieldMap(this IAttributeTable source, IAttributeTable target)
        {
            var dict = new Dictionary<int, int>();

            var fields = source.Fields;
            for (int i = 0; i < fields.Count; i++)
            {
                var fld = fields[i];
                var fldTarget = target.Fields[fld.Name];
                if (fldTarget == null || fld.Type != fldTarget.Type)
                {
                    continue;
                }
                int targetIndex = target.Fields.IndexByName(fldTarget.Name);
                if (targetIndex != -1)
                {
                    dict.Add(i, targetIndex);
                }
            }
            return dict;
        }

        public static bool ValidateFieldNameSlack(this IAttributeTable table, string newName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(newName))
            {
                errorMessage = "Field name is empty.";
                return false;
            }

            if (newName.Length > 10)
            {
                errorMessage = "Maximum field length is 10.";
                return false;
            }

            return true;
        }

        public static bool ValidateFieldName(this IAttributeTable table, string newName, out string errorMessage)
        {
            if (!ValidateFieldNameSlack(table, newName, out errorMessage))
            {
                return false;
            }

            if (table.Fields.Any(f => f.Name.EqualsIgnoreCase(newName)))
            {
                errorMessage = "Field name already exists.";
                return false;
            }

            return true;
        }

        public static IEnumerable<ValueCountItem> GetUniqueValues(this IAttributeTable table, int fieldIndex)
        {
            var hashTable = new SortedDictionary<string, int>();

            bool isString = (table.Fields[fieldIndex].Type == AttributeType.String);

            for (int i = 0; i < table.NumRows; i++)
            {
                var obj = table.CellValue(fieldIndex, i);
                string s = obj != null ? obj.ToString() : string.Empty;

                if (isString)
                {
                    s = "\"" + s + "\"";
                }

                if (hashTable.ContainsKey(s))
                {
                    hashTable[s] += 1;
                }
                else
                {
                    hashTable.Add(s, 1);
                }
            }

            return hashTable.Select(item => new ValueCountItem(item.Key, item.Value));
        }
    }
}