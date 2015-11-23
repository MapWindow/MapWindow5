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

			// TODO: remove when tested
            //string name = Path.GetFileNameWithoutExtension(inputFilename);
            //s = s.Replace(TemplateNameResolver.Input, name);

            s = TemplateNameResolver.Resolve(inputFilename, s, true);

            SetToolValue(s);
        }

        public override bool Serializable
        {
            get { return false; }
        }
    }
}
