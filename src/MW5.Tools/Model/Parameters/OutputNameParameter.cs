using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Helpers;

namespace MW5.Tools.Model.Parameters
{
    public class OutputNameParameter: StringParameter, IOutputParameter
    {
        public void ResolveTemplateName(string inputFilename)
        {
            var s = Value as string;
            
            if (string.IsNullOrWhiteSpace(s))
            {
                return;
            }

            string name = Path.GetFileNameWithoutExtension(inputFilename);

            s = s.Replace(TemplateVariables.Input, name);
            SetToolValue(s);
        }

        public override bool Serializable
        {
            get { return false; }
        }
    }
}
