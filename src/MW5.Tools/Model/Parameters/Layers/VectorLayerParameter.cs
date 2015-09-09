using System.IO;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Model.Parameters.Layers
{
    internal class VectorLayerParameter: LayerParameterBase
    {
        public override DataSourceType DataSourceType
        {
            get { return DataSourceType.Vector; }
        }

        public override object Value
        {
            get
            {
                if (Control != null)
                {
                    return Control.GetValue() as IVectorInput;
                }

                return base.Value;
            }
        }

        public override ILayerSource Datasource
        {
            get
            {
                var info = Value as IVectorInput;
                return info != null ? info.Datasource : null;
            }
        }
    }
}
