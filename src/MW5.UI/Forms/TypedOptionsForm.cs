// -------------------------------------------------------------------------------------------
// <copyright file="TypedOptionsForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016-2017
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Shared;

namespace MW5.UI.Forms
{
    public class TypedOptionsForm<T> : OptionsForm
        where T : struct, IConvertible
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

            
            Height = 180 + 23 * list.Count;
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

        public Color SelectedColor
        {
            get { return colorPicker.Color; }
            set { colorPicker.Color = value; }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // TypedOptionsForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            CaptionFont = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClientSize = new Size(378, 317);
            Name = "TypedOptionsForm";
            Load += TypedOptionsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void TypedOptionsForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}