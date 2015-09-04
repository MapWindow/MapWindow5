using System;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public class VectorLayerInfo: LayerInfo, IVectorLayerInfo
    {
        public VectorLayerInfo(IFeatureSet fs, bool selectedOnly = false)
            : base(fs)
        {
            if (fs == null) throw new ArgumentNullException("fs");
            SelectedOnly = selectedOnly;
        }

        public new IFeatureSet Datasource
        {
            get { return base.Datasource as IFeatureSet; }
            set { base.Datasource = value; }
        }

        public bool SelectedOnly { get; set; }
    }
}
