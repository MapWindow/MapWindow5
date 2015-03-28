using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Helpers
{
    public static class AttributeTableHelper
    {
        public static bool ValidateField(this IAttributeTable table, string newName, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (newName == string.Empty)
            {
                errorMessage = "Please enter a name.";
                return false;
            }

            if (newName.Length > 10)
            {
                errorMessage = "Max fieldlength is 10.";
                return false;
            }

            if (table.Fields.Any(f => f.Name.ToLower() == newName))
            {
                errorMessage = "Fieldname already exists or has been previously added/removed in this session. Apply or cancel your changes and try again.";
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
