using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    internal struct ColorInfo
    {
        #region "Member Variables"

        public Color StartColor;
        public Color EndColor;
        public string Caption;
        public bool IsTransparent;

        #endregion

        public ColorInfo(Color start, Color end, string pCaption, bool transparent)
        {
            StartColor = start;
            EndColor = end;
            Caption = pCaption;
            IsTransparent = transparent;
        }
        public ColorInfo(Color start, Color end, string pCaption)
        {
            StartColor = start;
            EndColor = end;
            Caption = pCaption;
            IsTransparent = false;

        }
    }

}
