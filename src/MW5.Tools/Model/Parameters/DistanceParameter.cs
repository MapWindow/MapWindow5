using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Tools.Views.Controls;

namespace MW5.Tools.Model.Parameters
{
    public class DistanceParameter: DoubleParameter
    {
        public DistanceParameter() { }

        public LengthUnits Units
        {
            get
            {
                var ctrl = Control as DistanceParameterControl;
                if (ctrl == null)
                {
                    throw new NullReferenceException("A control for distance parameter isn't specified");
                }

                return ctrl.Units;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:g3}", DisplayName, Value);
        }
    }
}
