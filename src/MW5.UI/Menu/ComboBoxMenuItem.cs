using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class ComboBoxMenuItem: MenuItem, IComboBoxMenuItem
    {
        private int _listenerCount = 0;
        private string _lastValue = string.Empty;

        internal ComboBoxMenuItem(BarItem item)
            : base(item)
        {
            var combo = ComboItem;
            combo.SizeToFit = true;
            combo.MaxDropDownItems = 10;
        }

        private void combo_Click(object sender, EventArgs e)
        {
            var combo = ComboItem;

            // the new value isn't assigned to TextBoxValue property when Enter is pressed
            // http: //www.syncfusion.com/forums/28969/using-comboboxbaritem
            // let's use this hack to get it
            var textBox = ReflectionHelper.GetInstanceField(combo, "ComboTextBox") as TextBoxBase;
            FireValueChanged(textBox != null ? textBox.Text : combo.TextBoxValue);
        }

        private void FireValueChanged(string newValue)
        {
            // Make sure that the event passed to listeners only once.
            // Both Click and TextBoxValueChange will be fired when user select and item
            // while in other cases only one of them is fired.
            if (newValue == _lastValue) return;
            _lastValue = newValue;

            var handler = _valueChanged;
            if (handler != null)
            {
                handler(this, new StringValueChangedEventArgs(newValue));
            }
        }

        private ComboBoxBarItem ComboItem
        {
            get { return _item as ComboBoxBarItem; }
        }

        public StringCollection DataSource
        {
            get { return ComboItem.ChoiceList; }
        }

        public int Width
        {
            get { return ComboItem.MinWidth; }
            set { ComboItem.MinWidth = value; }
        }

        private EventHandler<StringValueChangedEventArgs> _valueChanged;

        public event EventHandler<StringValueChangedEventArgs> ValueChanged
        {
            add
            {
                if (_listenerCount == 0)
                {
                    // fired when user selects item from list or presses Enter
                    ComboItem.Click += combo_Click;

                    // fired when user selects item from list or changes it with mouse wheel
                    ComboItem.TextBoxValueChange += (s, e) => FireValueChanged(e.NewValue);
                }

                _valueChanged += value;

                _listenerCount++;
            }
            remove
            {
                _listenerCount--;

                if (_listenerCount == 0)
                {
                    EventHelper.RemoveEventHandler(ComboItem, "Click");
                    EventHelper.RemoveEventHandler(ComboItem, "TextBoxValueChange");
                }

                _valueChanged -= value;
            }
        }

        public void Focus()
        {
            ComboItem.Focus();
        }

        public override string Text
        {
            get { return ComboItem.TextBoxValue; }
            set { ComboItem.TextBoxValue = value; }
        }
    }
}
