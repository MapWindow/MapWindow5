using System.IO;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Model.Parameters.Layers
{
    /// <summary>
    /// Layer of arbitrary type.
    /// </summary>
    internal class GenericLayerParameter: LayerParameterBase
    {
        public override DataSourceType DataSourceType
        {
            get { return DataSourceType.All; }
        }

        public override object Value
        {
            get
            {
                if (Control != null)
                {
                    return Control.GetValue() as ILayerInfo;
                }

                return base.Value;
            }
        }

        public override ILayerSource Datasource
        {
            get
            {
                var info = Value as ILayerInfo;
                return info != null ? info.Datasource : null;
            }
        }
    }
}
