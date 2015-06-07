using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Api.Events
{
    public class UpdateJoinEventArgs : EventArgs
    {
        public UpdateJoinEventArgs(string filename, string fieldList, string options, IAttributeTable tableToFill)
        {
            Filename = filename;
            FieldList = fieldList;
            Options = options;
            TableToFill = tableToFill;
        }

        public string Filename { get; private set; }
        public string FieldList { get; private set; }
        public string Options { get; private set; }
        public IAttributeTable TableToFill { get; private set; }
    }
}
