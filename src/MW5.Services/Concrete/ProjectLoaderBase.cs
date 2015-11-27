using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Services.Serialization;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public class ProjectLoaderBase : IProjectLoaderBase
    {
        protected void FireProgressChanged(int step, int total, string message)
        {
            double percent = step / (double)total * 100.0;

            DelegateHelper.FireEvent(this, ProgressChanged, new ProgressEventArgs(message, Convert.ToInt32(percent)));
        }

        public event EventHandler<ProgressEventArgs> ProgressChanged;
    }
}
