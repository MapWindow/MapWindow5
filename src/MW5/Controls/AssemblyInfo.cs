using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Controls
{
    public class AssemblyInfo
    {
        private readonly Assembly _asm;

        public AssemblyInfo(Assembly asm)
        {
            if (asm == null) throw new ArgumentNullException("asm");
            _asm = asm;
        }

        public string Name
        {
            get { return _asm.GetName().Name; }
        }

        public string Version
        {
            get { return _asm.GetName().Version.ToString(); }
        }
    }
}
