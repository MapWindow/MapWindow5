using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;

namespace MW5.Api.Concrete
{
    public class DatasourceDriver
    {
        private readonly IGdalDriver _driver;

        internal DatasourceDriver(IGdalDriver driver)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            _driver = driver;
        }

        public string get_Metadata(GdalDriverMetadata metadata)
        {
            return _driver.Metadata[(tkGdalDriverMetadata)metadata];
        }

        public int MetadataCount
        {
            get { return _driver.MetadataCount; }
        }

        public string get_MetadataName(int metadataIndex)
        {
            var s = _driver.MetadataItem[metadataIndex];
            var parts = s.Split('=');
            return parts.Length == 2 ? parts[0] : string.Empty;
        }

        public string get_MetadataValue(int metadataIndex)
        {
            var s = _driver.MetadataItem[metadataIndex];
            var parts = s.Split('=');
            return parts.Length == 2 ? parts[1] : string.Empty;
        }

        public string Description
        {
            get { return _driver.Description; }
        }
    }
}
