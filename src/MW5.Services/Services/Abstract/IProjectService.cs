using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Services.Serialization;

namespace MW5.Services.Services.Abstract
{
    public interface IProjectService
    {
        bool Save(ISerializableContext context);
        bool Open(ISerializableContext context);
    }
}
