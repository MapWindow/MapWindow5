using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.UI.Controls
{
    /// <summary>
    /// Represents an item that can be displayed in StronglyTypedGrid ComboBox.
    /// </summary>
    public class GridComboItem
    {
        public GridComboItem(string text, object value)
        {
            Value = value;
            Text = text;
        }

        public object Value { get; private set; }

        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// Creates grid combobox items for specified enumeration.
        /// </summary>
        public static IEnumerable<GridComboItem> CreateForEnum<T>()
            where T: struct, IConvertible
        {
            var values = Enum.GetValues(typeof(T));
            
            foreach (T value in values)
            {
                yield return new GridComboItem(value.EnumToString(), value);
            }
        }

        /// <summary>
        /// Creates grid combobox items for specified enumeration.
        /// </summary>
        public static IEnumerable<GridComboItem> CreateForEnum<T>(IEnumerable<T> values)
            where T : struct, IConvertible
        {
            foreach (T value in values)
            {
                yield return new GridComboItem(value.EnumToString(), value);
            }
        }
    }
}
