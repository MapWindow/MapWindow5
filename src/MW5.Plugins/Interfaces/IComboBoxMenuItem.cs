using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    public interface IComboBoxMenuItem: IMenuItem
    {
        StringCollection DataSource { get; }
        int Width { get; set; }
        event EventHandler<StringValueChangedEventArgs> ValueChanged;
        void Focus();
    }
}
