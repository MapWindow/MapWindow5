using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Api.Legend.Events
{
    public class DatasourceCancelEventArgs: CancelEventArgs, ICancellableEvent
    {
        public DatasourceCancelEventArgs(ILayerSource datasource)
        {
            Datasource = datasource;
        }

        public ILayerSource Datasource { get; private set; }
    }
}
