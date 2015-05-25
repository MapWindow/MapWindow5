using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Data.Enums
{
    public class DriverFilterConverter: IEnumConverter<DriverFilter>
    {
        public string GetString(DriverFilter value)
        {
            switch (value)
            {
                case DriverFilter.All:
                    return "All";
                case DriverFilter.Create:
                    return "Supports creation";
                case DriverFilter.CreateCopy:
                    return "Supports copying";
                case DriverFilter.VirtualIo:
                    return "Supports virtual IO";
                case DriverFilter.HasCreationOptions:
                    return "Has creation options";
                case DriverFilter.HasOpenOptions:
                    return "Has open options";
                case DriverFilter.HasLayerCreationOptions:
                    return "Has layer creation options";
            }

            return string.Empty;
        }
    }
}
