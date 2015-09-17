using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    public interface IOuputputParameterControl
    {
        void SetExtension(string extension);

        void OnFilenameChanged(string filename);

        void OnDatasourceChanged(IDatasourceInput input);
    }
}
