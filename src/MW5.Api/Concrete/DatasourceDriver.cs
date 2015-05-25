using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class DatasourceDriver: IEnumerable<DriverMetadata>
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

        public string get_MetadataItemKey(int metadataIndex)
        {
            return _driver.MetadataItemKey[metadataIndex];
        }

        public string get_MetadataItemValue(int metadataIndex)
        {
            return _driver.MetadataItemValue[metadataIndex];
        }

        public GdalDriverMetadata get_MetadataItemType(int metadataIndex)
        {
            return (GdalDriverMetadata)_driver.MetadataItemType[metadataIndex];
        }

        public string Name
        {
            get { return _driver.Name; }
        }

        public bool IsVector
        {
            get { return _driver.IsVector; }
        }

        public bool IsRaster
        {
            get { return _driver.IsRaster; }
        }

        public string Extension
        {
            get { return get_Metadata(GdalDriverMetadata.Extension); }
        }

        public string Extensions
        {
            get { return get_Metadata(GdalDriverMetadata.Extensions); }
        }

        public string LongName
        {
            get { return get_Metadata(GdalDriverMetadata.Longname); }
        }

        public DriverMetadata this[int index]
        {
            get
            {
                if (index < 0 || index >= MetadataCount)
                {
                    return null;
                }

                return new DriverMetadata(
                    get_MetadataItemKey(index), 
                    get_MetadataItemValue(index), 
                    get_MetadataItemType(index));
            }
        }

        public IEnumerator<DriverMetadata> GetEnumerator()
        {
            for (int i = 0; i < MetadataCount; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MatchesFilter(DriverFilter filter)
        {
            switch (filter)
            {
                case DriverFilter.All:
                    return true;
                case DriverFilter.Create:
                    return !string.IsNullOrWhiteSpace(get_Metadata(GdalDriverMetadata.Create));
                case DriverFilter.CreateCopy:
                    return !string.IsNullOrWhiteSpace(get_Metadata(GdalDriverMetadata.CreateCopy));
                case DriverFilter.VirtualIo:
                    return !string.IsNullOrWhiteSpace(get_Metadata(GdalDriverMetadata.VirtualIo));
                case DriverFilter.HasCreationOptions:
                    return !string.IsNullOrWhiteSpace(get_Metadata(GdalDriverMetadata.CreationOptionList));
                case DriverFilter.HasOpenOptions:
                    return !string.IsNullOrWhiteSpace(get_Metadata(GdalDriverMetadata.OpenOptionList));
                case DriverFilter.HasLayerCreationOptions:
                    return !string.IsNullOrWhiteSpace(get_Metadata(GdalDriverMetadata.LayerCreationOptionList));
            }

            return true;
        }

        public bool MatchesFilter(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return true;
            }

            return Name.ContainsIgnoreCase(token) ||
                LongName.ContainsIgnoreCase(token) ||
                Extensions.ContainsIgnoreCase(token);
        }
    }
}
