using System;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public class VectorInput: DatasourceInput, IVectorInput
    {
        public VectorInput(IFeatureSet fs, bool selectedOnly = false)
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

        /// <summary>
        /// Gets or sets a value indicating whether only selected features of the input layer should be processed.
        /// </summary>
        public bool SelectedOnly { get; set; }
    }
}
