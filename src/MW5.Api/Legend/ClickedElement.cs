using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    /// <summary>
    /// The element of legend that was clicked
    /// </summary>
    public class ClickedElement
    {
        public bool LabelsIcon = false;
        public bool ColorBox = false;
        public bool CheckBox = false;
        public bool ExpansionBox = false;
        public bool Charts = false;
        public bool Label = false;
        public int ChartFieldIndex = -1;
        public int CategoryIndex = -1;
        public int GroupIndex = -1;

        public void Nullify()
        {
            ColorBox = false;
            CheckBox = false;
            ExpansionBox = false;
            Charts = false;
            Label = false;
            ChartFieldIndex = -1;
            CategoryIndex = -1;
            GroupIndex = -1;
        }
    }
}
