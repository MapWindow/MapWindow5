using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Controls.Parameters;

namespace MW5.Tools.Model.Parameters
{
    internal class FieldParameter : BaseParameter
    {
        public VectorLayerParameter Layer { get; set; }

        public override object Value
        {
            get { return (int)Control.GetValue(); }
        }
    }
}
