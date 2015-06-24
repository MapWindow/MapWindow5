using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Services;

namespace MW5.Plugins.Symbology.Views
{
    public class CategoriesSubViewModel
    {
        public CategoriesSubViewModel(ILegendLayer layer, SymbologyMetadata metadata)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            if (metadata == null) throw new ArgumentNullException("metadata");

            Layer = layer;
            Metadata = metadata;
        }

        public ILegendLayer Layer { get; set; }

        public SymbologyMetadata Metadata { get; set; }

        public IFeatureSet FeatureSet 
        {
            get { return Layer.FeatureSet; }
        }
    }
}
