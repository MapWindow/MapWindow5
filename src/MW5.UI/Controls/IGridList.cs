using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Controls
{
    public interface IGridList<T>
        where T: class
    {
        T SelectedItem { get; }
        IEnumerable<T> Items { get; }
    }
}
