using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.UI.Helpers;

namespace MW5.UI.Repository
{
    public class RepositoryItemTypeConverter : IEnumConverter<RepositoryItemType>
    {
        public string GetString(RepositoryItemType value)
        {
            switch (value)
            {
                case RepositoryItemType.Folders:
                    return "File System";
                case RepositoryItemType.Folder:
                    return "Folder";
                case RepositoryItemType.Vector:
                    return "Vector layer";
            }

            return "";
        }
    }
}
