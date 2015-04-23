using System;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public interface IParameterControl
    {
        event EventHandler<EventArgs> ValueChanged;
        TableLayoutPanel GetTable();
        string Caption { get; set; }
        object GetValue();
    }
}
