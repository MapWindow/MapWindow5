using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Services
{
    public interface IToolProgress
    {
        void Update(string msg, int value);

        void Clear();

        event EventHandler<ProgressEventArgs> ProgressChanged;
    }
}
