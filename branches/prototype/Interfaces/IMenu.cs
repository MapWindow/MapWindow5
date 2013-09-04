using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IMenu
    {
        void OptieEen();

        event EventHandler OnButtonClicked;
    }
}
