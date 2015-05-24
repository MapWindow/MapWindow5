using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

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
    }
}
