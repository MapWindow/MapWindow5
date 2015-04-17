using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Controls
{
    internal class NodeData
    {
        private List<NodeData> _subItems;

        public NodeData(string name)
        {
            Name = name;
            Value = string.Empty;
        }

        public NodeData(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }

        public void AddSubItem(NodeData pair)
        {
            CheckSubItems();
            _subItems.Add(pair);
        }

        public void AddSubItem(string name, string value)
        {
            CheckSubItems();
            _subItems.Add(new NodeData(name, value));
        }

        public void AddSubItem(string name, double value)
        {
            CheckSubItems();
            _subItems.Add(new NodeData(name, value.ToString(CultureInfo.InvariantCulture)));
        }

        public IEnumerable<NodeData> SubItems
        {
            get
            {
                CheckSubItems();
                return _subItems;
            }
        }

        private void CheckSubItems()
        {
            if (_subItems == null)
            {
                _subItems = new List<NodeData>();
            }
        }
    }
}
