using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.Model
{
    internal class VectorItem: RepositoryItem, IVectorItem
    {
        internal VectorItem(TreeNodeAdv node) : base(node)
        {
        }

        private VectorItemMetadata Metadata
        {
            get
            {
                var data = _node.TagObject as VectorItemMetadata;
                if (data == null)
                {
                    throw new InvalidCastException("VectorItemMetadata object must be stored in the tag.");
                }

                return data;
            }
        }

        public string Filename
        {
            get
            {
                return Metadata.Filename;
            }
        }

        public void Load()
        {

        }
    }
}
