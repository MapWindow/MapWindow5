using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Shared;

namespace MW5.Plugins.Enums
{
    public class GisTaskStatusConverter: IEnumConverter<GisTaskStatus>
    {
        public string GetString(GisTaskStatus value)
        {
            switch (value)
            {
                case GisTaskStatus.NotStarted:
                    return "Not started";
                case GisTaskStatus.Running:
                    return "Running";
                case GisTaskStatus.Success:
                    return "Success";
                case GisTaskStatus.Failed:
                    return "Failed";
                case GisTaskStatus.Cancelled:
                    return "Cancelled";
                case GisTaskStatus.Paused:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("value");
            }

            return string.Empty;
        }
    }

    public class TilesMaxAgeConverter : IEnumConverter<TilesMaxAge>
    {
        public string GetString(TilesMaxAge value)
        {
            switch (value)
            {
                case TilesMaxAge.Never:
                    return "Never";
                case TilesMaxAge.Month:
                    return "1 month";
                case TilesMaxAge.Month3:
                    return "3 month";
                case TilesMaxAge.Month6:
                    return "6 month";
                case TilesMaxAge.Year:
                    return "1 year";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }
    }
}
