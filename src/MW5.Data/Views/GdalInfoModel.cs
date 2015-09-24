using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Data.Repository;

namespace MW5.Data.Views
{
    public class GdalInfoModel
    {
        public GdalInfoModel(IFileItem item)
        {
            Filename = item.Filename;
            Datasource = item;
        }

        public IFileItem Datasource { get; private set;}

        public string Filename { get; private set; }
    }
}
