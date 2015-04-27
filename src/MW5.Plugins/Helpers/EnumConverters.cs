using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Plugins.Helpers
{
    public class GdalDriverMetadataConverter : IEnumConverter<GdalDriverMetadata>
    {
        public string GetString(GdalDriverMetadata value)
        {
            switch (value)
            {
                case GdalDriverMetadata.Longname:
                    return "Long name";
                case GdalDriverMetadata.HelpTopic:
                    return "Help topic";
                case GdalDriverMetadata.MimeType:
                    return "Mime type";
                case GdalDriverMetadata.Extension:
                    return "Extension";
                case GdalDriverMetadata.Extensions:
                    return "Extensions";
                case GdalDriverMetadata.CreationOptionList:
                    return "Creation option list";
                case GdalDriverMetadata.OpenOptionList:
                    return "Open option list";
                case GdalDriverMetadata.CreationDataTypes:
                    return "Creation data types";
                case GdalDriverMetadata.SubDatasets:
                    return "Sub datasets";
                case GdalDriverMetadata.Open:
                    return "Supports open";
                case GdalDriverMetadata.Create:
                    return "Supports creation";
                case GdalDriverMetadata.CreateCopy:
                    return "Supports create copy";
                case GdalDriverMetadata.VirtualIo:
                    return "Supports virtual IO";
                case GdalDriverMetadata.LayerCreationOptionList:
                    return "Layer creation option list";
                case GdalDriverMetadata.OgrDriver:
                    return "Is OGR driver";
            }

            return string.Empty;
        }
    }
}
