using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Parameters
{
    internal class LayerParameter: LayerParameterBase<ILayerSource>
    {
        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Path.GetFileName(Datasource.Filename));
        }

        public override object Value
        {
            get
            {
                var wrapper = Control.GetValue() as LayerWrapper;
                if (wrapper != null)
                {
                    return wrapper.Source;
                }

                return null;
            }
        }
    }
}
