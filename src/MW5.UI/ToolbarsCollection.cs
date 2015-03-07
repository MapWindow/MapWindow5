using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class ToolbarsCollection: IToolbarCollection
    {
        private MainFrameBarManager _manager;

        internal static IToolbarCollection CreateInstance(object menuManager)
        {
            var collection = new ToolbarsCollection(menuManager);
            return collection;
        }

        private ToolbarsCollection(object menuManager)
        {
            _manager = menuManager as MainFrameBarManager;
            if (_manager == null)
            {
                throw new NullReferenceException("ToolbarsCollection: instance of menu manager is not provided.");
            }
        }

        public IEnumerator<IToolbar> GetEnumerator()
        {
            for (int i = 0; i < _manager.Bars.Count; i++)
            {
                yield return this[i];
            }
        }

        public IToolbar this[int index]
        {
            get
            {
                if (index < 0 || index >= _manager.Bars.Count)
                {
                    throw new IndexOutOfRangeException("Invalid toolbar index.");
                }
                return new Toolbar(_manager, _manager.Bars[index]);
            }
        }

        public IMenuItem FindItem(string key)
        {
            // TODO: implement
            return null;
        }

        public IToolbar Add(string name)
        {
            var bar = new Bar(_manager, name);
            int index = _manager.Bars.Add(bar);
            return new Toolbar(_manager, _manager.Bars[index]);
        }

        public void Remove(int toolbarIndex)
        {
            _manager.Bars.RemoveAt(toolbarIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
