using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace MW5.UI.Controls
{
    public class NodeData
    {
        private List<NodeData> _subItems;

        public NodeData(string name) :
            this(name, string.Empty) { }

        public NodeData(string name, string value)
        {
            Name = name;
            Value = value;
            ImageIndex = -1;
            Expanded = true;
            LargerHeight = false;
        }

        public string Name { get; private set; }
        public string Value { get; set; }
        public int ImageIndex { get; set; }
        public bool Expanded { get; set; }
        public bool LargerHeight { get; set; }
        public object Metadata { get; set; }

        public void AddSubItem(NodeData pair)
        {
            CheckSubItems();
            _subItems.Add(pair);
        }

        public NodeData AddSubItem(string name, string value)
        {
            CheckSubItems();
            var data = new NodeData(name, value);
            _subItems.Add(data);
            return data;
        }

        public NodeData AddSubItem(string name, double value)
        {
            CheckSubItems();
            var data = new NodeData(name, value.ToString("0.####", CultureInfo.InvariantCulture));
            _subItems.Add(data);
            return data;
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
