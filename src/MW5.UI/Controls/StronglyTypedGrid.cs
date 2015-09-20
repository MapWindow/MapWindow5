using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Services;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.UI.Controls
{
    public abstract class StronglyTypedGrid<T> : CustomGridControl
            where T : class
    {
        public GridAdapter<T> Adapter { get; protected set; }

        protected StronglyTypedGrid()
        {
            Adapter = new GridAdapter<T>(this);
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = null;
                base.DataSource = value;

                UpdateColumns();
            }
        }

        protected abstract void UpdateColumns();
    }
}
