using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Core.Interfaces
{
    // at least to prevent adding types that are not suppported
    public interface IDatasource: IComWrapper
    {
        string Filename { get; }

        void Close();

        string OpenDialogFilter { get; }
    }
}
