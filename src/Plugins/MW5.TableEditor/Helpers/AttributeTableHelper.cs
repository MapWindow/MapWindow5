using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Helpers
{
    public static class AttributeTableHelper
    {
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

            if (table.Fields.Any(f => f.Name.ContainsIgnoreCase(newName)))
            {
                errorMessage = "Field name already exists.";
                return false;
            }

            return true;
        }

        public static void CheckEditMode(this IAttributeTable table, bool expected)
        {
            if (expected && !table.EditMode)
            {
                throw new InvalidOperationException("Table in edit mode is expected.");
            }
        }
    }
}
