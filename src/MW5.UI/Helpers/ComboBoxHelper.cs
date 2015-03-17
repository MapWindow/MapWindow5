using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Helpers
{
    public static class ComboBoxHelper
    {
        public static void AddItemsFromEnum<T>(this ComboBoxAdv box) where T: struct, IConvertible
        {
            var t = new T();
            var items = EnumHelper.GetComboItems(Enum.GetValues(t.GetType()).OfType<T>());
            foreach (var item in items)
            {
                box.Items.Add(item);
            }
        }
        
        public static T GetValue<T>(this ComboBoxAdv box) where T: struct, IConvertible
        {
            var item = box.SelectedItem as ComboBoxEnumItem<T>;
            if (item == null)
            {
                throw new InvalidCastException("ComboBoxEnumItem was expected");
            }
            return item.GetValue();
        }

        public static void SetValue<T>(this ComboBoxAdv box, T value) where T : struct, IConvertible
        {
             foreach (var item in box.Items)
             {
                 var enumItem = item as ComboBoxEnumItem<T>;
                 if (enumItem == null)
                 {
                     throw new InvalidCastException("ComboBoxEnumItem was expected");
                 }
                 if (enumItem.GetValue().Equals(value))
                 {
                     box.SelectedItem = item;
                     break;
                 }
             }
        }
    }
}
