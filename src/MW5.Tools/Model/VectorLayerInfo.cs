using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model
{
    public class VectorLayerInfo
    {
        public VectorLayerInfo(IFeatureSet fs, bool selectedOnly = false)
        {
            if (fs == null) throw new ArgumentNullException("fs");
            SelectedOnly = selectedOnly;
            Datasource = fs;
        }

        public IFeatureSet Datasource { get; set; }

        public bool SelectedOnly { get; set; }
    }
}
