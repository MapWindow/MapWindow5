using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Api.Legend.Events
{
    public class GroupMouseEventArgs: GroupEventArgs
    {
        public MouseButtons Button { get; internal set; }

        public GroupMouseEventArgs(int groupHandle, MouseButtons buttons) : base(groupHandle)
        {
            Button = buttons;
        }
    }
}
