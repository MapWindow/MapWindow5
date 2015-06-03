using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class DriverManager: IEnumerable<DatasourceDriver>
    {
        private readonly IGdalDriverManager _manager;

        public DriverManager()
        {
            _manager = new GdalDriverManager();
        }

        public int DriverCount
        {
            get { return _manager.DriverCount; }
        }

        public DatasourceDriver SelectedDriver { get; set; }

        public DatasourceDriver get_Driver(int driverIndex)
        {
            var gdalDriver = _manager.Driver[driverIndex];
            return gdalDriver != null ? new DatasourceDriver(gdalDriver) : null;
        }

        public DatasourceDriver get_DriverByName(string driverName)
        {
            var gdalDriver = _manager.DriverByName[driverName];
            return gdalDriver != null ? new DatasourceDriver(gdalDriver) : null;
        }

        public DatasourceDriver this[int index]
        {
            get
            {
                if (index < 0 || index >= DriverCount)
                {
                    throw new ArgumentOutOfRangeException("Invalid driver index");
                }

                return get_Driver(index);
            }
        }

        public IEnumerator<DatasourceDriver> GetEnumerator()
        {
            for (int i = 0; i < DriverCount; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<string> GetExtensions(SelectedLayerType layerType, bool forCommodDialog)
        {
            List<DatasourceDriver> list = null;

            switch(layerType)
            {
                case SelectedLayerType.Undefined:
                    list = this.ToList();
                    break;
                case SelectedLayerType.Vector:
                    list = this.Where(d => d.IsVector).ToList();
                    break;
                case SelectedLayerType.Raster:
                    list = this.Where(d => d.IsRaster).ToList();
                    break;
                default:
                    return new List<string>();
            }

            return list.Select(d => d.Extension)
                       .Where(ext => !string.IsNullOrWhiteSpace(ext))
                       .OrderBy(ext => ext)
                       .Select(ext => forCommodDialog ? "*." + ext : ext)
                       .ToList();
        }

        public void DumpExtensions(bool openDialog)
        {
            var values = Enum.GetValues(typeof (SelectedLayerType));

            foreach (SelectedLayerType value in values)
            {
                var list = GetExtensions(value, openDialog);
                Debug.Print(value + " formats");    
                Debug.Print(StringHelper.Join(list, "|"));
                Debug.Print("");
            }
        }
    }
}
