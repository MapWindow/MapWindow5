using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Shared;

namespace MW5.UI.Forms
{
    public class TypedOptionsForm<T>: OptionsForm where T: struct, IConvertible
    {
        private readonly List<RadioButton> _list;

        public TypedOptionsForm(IEnumerable<T> options, string text)
        {
            if (options == null) throw new ArgumentNullException("options");

            var list = options.ToList();

            lblText.Text = text;

            _list = new List<RadioButton>();
            for (int i = 0; i < list.Count; i++)
            {
                var button = new RadioButton();
                _list.Add(button);

                button.Parent = this;
                button.Left = 20;
                button.Top = 50 + 23 * i;
                button.Text = list[i].EnumToString();
                button.AutoSize = true;
                button.Tag = list[i];
            }

            Height = 150 + 23 * list.Count;
        }

        public T SelectedItem
        {
            get
            {
                foreach (RadioButton t in _list)
                {
                    if (t.Checked)
                    {
                        return (T)t.Tag;
                    }
                }

                return default(T);
            }

            set
            {
                var button = _list.FirstOrDefault(item => ((T)item.Tag).Equals(value));
                if (button != null)
                {
                    button.Checked = true;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TypedOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(378, 217);
            this.Name = "TypedOptionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
