using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Services.Serialization
{
    public interface IProjectLoader
    {
        bool Restore(XmlProject project);
    }
}
