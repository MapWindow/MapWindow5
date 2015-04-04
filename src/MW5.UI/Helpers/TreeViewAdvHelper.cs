using System.Linq;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Helpers
{
    public static class TreeViewAdvHelper
    {
        public static int GetImageIndex(this TreeNodeAdv node)
        {
            return node.LeftImageIndices.Count() > 0 ? node.LeftImageIndices[0] : -1;
        }

        public static TreeNodeAdv CreateNode(this TreeNodeAdvCollection nodes, string key, string text, int imageIndex)
        {
            var node = new TreeNodeAdv(text)
            {
                LeftImageIndices = new[] { imageIndex },
                TagObject = key,
            };
            
            return node;
        }

        public static TreeNodeAdv Add(this TreeNodeAdvCollection nodes, string key, string text, int imageIndex)
        {
            var node = CreateNode(nodes, key, text, imageIndex);
            
            nodes.Add(node);

            return node;
        }

        public static TreeNodeAdv Find(this TreeNodeAdvCollection nodes, string key)
        {
            foreach (TreeNodeAdv n in nodes)
            {
                if (n.TagObject == null)
                {
                    continue;
                }
                
                if ((string)n.TagObject == key)
                {
                    return n;
                }
            }

            return null;
        }
    }
}
