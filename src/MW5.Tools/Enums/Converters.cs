using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Tools.Enums
{
    internal class FieldOperationValidityConverter : IEnumConverter<MW5.Api.Enums.FieldOperationValidity>
    {
        public string GetString(FieldOperationValidity value)
        {
            switch (value)
            {
                case FieldOperationValidity.Valid:
                    return "Valid";
                case FieldOperationValidity.FieldNotFound:
                    return "Field wasn't found";
                case FieldOperationValidity.NotSupported:
                    return "Operations isn't supported for the given field type.";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }
    }
}
