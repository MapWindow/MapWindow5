using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Mvp
{
    public class ViewStyle
    {
        public bool Modal { get; set; }
        public bool Sizable { get; set; }

        public ViewStyle(bool sizable)
        {
            Modal = true;
            Sizable = sizable;
        }

        public ViewStyle()
        {
            
        }
    }
}
